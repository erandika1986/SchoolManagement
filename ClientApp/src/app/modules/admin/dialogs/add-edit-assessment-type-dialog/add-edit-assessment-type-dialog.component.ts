import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, FormControl } from '@angular/forms';
import { AssessmentTypeModel } from '../../../../models/master/assessment-type/assessment-type.model';
import { AssessmentTypeService } from '../../../../services/admin/assessment-type.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventService } from '../../../../services/common/event.service';

@Component({
  selector: 'app-add-edit-assessment-type-dialog',
  templateUrl: './add-edit-assessment-type-dialog.component.html',
  styleUrls: ['./add-edit-assessment-type-dialog.component.css']
})
export class AddEditAssessmentTypeDialogComponent implements OnInit {

  form: FormGroup;

  recordId = 0;
  assessmentTypeId = 0;


  assessmentType: AssessmentTypeModel;

  constructor(private formBuilder: FormBuilder,
    private assessmentTypeService: AssessmentTypeService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    private eventService: EventService,
    public modalRef: BsModalRef) { }

  ngOnInit(): void {

    this.setForm();
    if (this.assessmentTypeId > 0) {
      this.loadData();
    }
    else {
      this.getEmptySubject();
    }
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      name: [''],
      description: [''],
      isActive: [true],
      academicLevels: new FormArray([])
    });
  }

  loadData() {
    this.assessmentTypeService.getAssessmentTypeById(this.assessmentTypeId)
      .subscribe(response => {
        this.assessmentType = response;

        console.log(response);


        this.form.get('id').setValue(response.id);
        this.form.get('name').setValue(response.name);
        this.form.get('description').setValue(response.description);
        this.form.get('isActive').setValue(response.isActive);
        let academicLevels = this.form.get("academicLevels") as FormArray;

        response.academicLevels.forEach(obj => {

          let item = new FormGroup({
            id: new FormControl(obj.id),
            description: new FormControl(obj.description),
            isChecked: new FormControl(obj.isChecked)
          });
          academicLevels.push(item);

        });
      }, error => {

      });
  }

  getEmptySubject() {
    this.assessmentTypeService.getEmptyAssessmentType().subscribe(response => {
      this.assessmentType = response;
      let academicLevels = this.form.get("academicLevels") as FormArray;
      response.academicLevels.forEach(obj => {

        let item = new FormGroup({
          id: new FormControl(obj.id),
          description: new FormControl(obj.description),
          isChecked: new FormControl(obj.isChecked)
        });
        academicLevels.push(item);
      });

    }, error => {

    });
  }

  getParentAcademicLevelDetails() {

  }

  save() {
    console.log("1");

    this.modalRef.hide();
    let at = this.form.getRawValue() as AssessmentTypeModel;
    // console.log(sb);
    this.eventService.assessmentTypeSaved(at);
  }

  cancel() {
    this.modalRef.hide();
  }

  getControlLabel(type: string) {
    return this.form.controls[type].value;
  }


  get academicLevels() {
    return this.form.get("academicLevels") as FormArray;
  }
}
