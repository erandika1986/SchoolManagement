import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AcademicYearService } from '../../../../services/admin/academic-year.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventService } from '../../../../services/common/event.service';
import { AcademicYearModel } from '../../../../models/master/academic-year/academic-year.model';

@Component({
  selector: 'app-add-edit-academic-year-dialog',
  templateUrl: './add-edit-academic-year-dialog.component.html',
  styleUrls: ['./add-edit-academic-year-dialog.component.css']
})
export class AddEditAcademicYearDialogComponent implements OnInit {

  recordId = 0;
  academicYearId = 0;
  action: string;

  academicYear: AcademicYearModel = new AcademicYearModel();

  constructor(
    private formBuilder: FormBuilder,
    private academicYearService: AcademicYearService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    private eventService: EventService,
    public modalRef: BsModalRef
  ) {

  }

  ngOnInit(): void {
    console.log(this.academicYearId);
    console.log(this.action);
    this.loadData();
  }



  loadData() {
    this.academicYearService.getSelectedAcademicYearClassDetailById(this.academicYearId)
      .subscribe(response => {

        this.academicYear = response;
        if (this.academicYear.academicYear == 0) {
          this.academicYear.academicYear = (new Date()).getFullYear();
        }

      }, error => {

      });
  }


  save() {


    this.eventService.academicYearSaved(this.academicYear);
  }

  cancel() {
    this.modalRef.hide();
  }


}
