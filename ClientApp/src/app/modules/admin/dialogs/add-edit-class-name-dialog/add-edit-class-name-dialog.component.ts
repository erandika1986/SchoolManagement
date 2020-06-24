import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ClassNameModel } from '../../../../models/master/class-name/class-name.model';
import { ClassNameService } from '../../../../services/admin/class-name.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventService } from '../../../../services/common/event.service';

@Component({
  selector: 'app-add-edit-class-name-dialog',
  templateUrl: './add-edit-class-name-dialog.component.html',
  styleUrls: ['./add-edit-class-name-dialog.component.css']
})
export class AddEditClassNameDialogComponent implements OnInit {

  form: FormGroup;

  recordId = 0;
  classNameId = 0;


  className: ClassNameModel;

  constructor(
    private formBuilder: FormBuilder,
    private classNameService: ClassNameService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    private eventService: EventService,
    public modalRef: BsModalRef
  ) { }

  ngOnInit(): void {
    this.setForm();
    if (this.classNameId > 0) {
      this.loadData();
    }
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      name: [''],
      description: [''],
      isActive: [true]
    });
  }



  loadData() {
    this.classNameService.getClassNameById(this.classNameId)
      .subscribe(response => {
        this.form.get('id').setValue(response.id);
        this.form.get('name').setValue(response.name);
        this.form.get('description').setValue(response.description);
        this.form.get('isActive').setValue(response.isActive);
      }, error => {

      });
  }



  save() {
    console.log("1");

    this.modalRef.hide();
    let cl = this.form.value as ClassNameModel;
    this.eventService.classNameSaved(cl);
  }

  cancel() {
    this.modalRef.hide();
  }

}
