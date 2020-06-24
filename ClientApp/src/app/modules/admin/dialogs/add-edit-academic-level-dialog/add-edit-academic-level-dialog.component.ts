import { Component, OnInit } from '@angular/core';
import { AcademicLevelModel } from '../../../../models/master/academic-level/academic-level.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AcademicLevelService } from '../../../../services/admin/academic-level.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../../models/common/drop-down.model';
import { EventService } from '../../../../services/common/event.service';

@Component({
  selector: 'app-add-edit-academic-level-dialog',
  templateUrl: './add-edit-academic-level-dialog.component.html',
  styleUrls: ['./add-edit-academic-level-dialog.component.css']
})
export class AddEditAcademicLevelDialogComponent implements OnInit {

  form: FormGroup;

  recordId = 0;
  academicLevelId;

  hods: DropDownModel[] = [];

  academicLevel: AcademicLevelModel;

  constructor(private formBuilder: FormBuilder,
    private academicLevelService: AcademicLevelService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    private eventService: EventService,
    public modalRef: BsModalRef) { }

  ngOnInit(): void {

    this.setForm();
    this.loadMasterData();
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      description: [''],
      levelHeadId: [0],
      isActive: [true]
    });
  }

  loadMasterData() {
    this.academicLevelService.getSchoolHods().subscribe(response => {

      this.hods = response;

      if (this.hods.length > 0) {
        if (this.academicLevelId === 0) {
          this.form.get('levelHeadId').setValue(this.hods[0].id);
        }
        else {
          this.loadData();
        }
      }


    }, error => {

    })
  }

  loadData() {
    this.academicLevelService.getAcademicLevelById(this.academicLevelId)
      .subscribe(response => {
        this.form.get('id').setValue(response.id);
        this.form.get('description').setValue(response.description);
        this.form.get('levelHeadId').setValue(response.levelHeadId);
        this.form.get('isActive').setValue(response.isActive);
      }, error => {

      });
  }

  hodChanged(e) {

  }

  save() {

    let al = this.form.value as AcademicLevelModel;
    this.eventService.academicLevelSaved(al);
  }

  cancel() {
    this.modalRef.hide();
  }

}
