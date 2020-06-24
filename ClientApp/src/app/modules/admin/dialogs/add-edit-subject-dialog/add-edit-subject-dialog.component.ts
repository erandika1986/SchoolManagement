import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, FormControl } from '@angular/forms';
import { SubjectModel } from '../../../../models/master/subject/subject.model';
import { SubjectService } from '../../../../services/admin/subject.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventService } from '../../../../services/common/event.service';
import { NgOption } from '@ng-select/ng-select';
import { BasicSubjectModel } from '../../../../models/master/common/basic-subject.model';

@Component({
  selector: 'app-add-edit-subject-dialog',
  templateUrl: './add-edit-subject-dialog.component.html',
  styleUrls: ['./add-edit-subject-dialog.component.css']
})
export class AddEditSubjectDialogComponent implements OnInit {

  form: FormGroup;

  recordId = 0;
  subjectId = 0;
  parentSubjects: BasicSubjectModel[];
  booleanSelection = [{ "value": true, "text": "Yes" }, { "value": false, "text": "No" }]


  subject: SubjectModel;

  constructor(
    private formBuilder: FormBuilder,
    private subjectService: SubjectService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    private eventService: EventService,
    public modalRef: BsModalRef
  ) { }

  ngOnInit(): void {

    this.setForm();
    if (this.subjectId > 0) {
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
      subjectCode: [''],
      isBasketSubject: [false],
      isParentBasketSubject: [false],
      subjectCategory: [1],
      isActive: [true],
      parentSubjectId: [0],
      academicLevels: new FormArray([])
    });
  }

  loadData() {
    this.subjectService.getSubjectById(this.subjectId)
      .subscribe(response => {
        this.subject = response;
        this.parentSubjects = response.parentSubjects;

        this.form.get('id').setValue(response.id);
        this.form.get('name').setValue(response.name);
        this.form.get('subjectCode').setValue(response.subjectCode);
        this.form.get('isBasketSubject').setValue(response.isBasketSubject);
        this.form.get('isParentBasketSubject').setValue(response.isParentBasketSubject);
        this.form.get('subjectCategory').setValue(response.subjectCategory);
        this.form.get('isActive').setValue(response.isActive);
        this.form.get('parentSubjectId').setValue(response.parentSubjectId);
        let academicLevels = this.form.get("academicLevels") as FormArray;



        response.academicLevels.forEach(obj => {

          let item = new FormGroup({
            id: new FormControl(obj.id),
            description: new FormControl(obj.description),
            isChecked: new FormControl(obj.isChecked),
            noOfPeriodPerWeek: new FormControl(obj.noOfPeriodPerWeek)
          });

          if (response.isBasketSubject) {
            item.get('isChecked').disable();
            item.get('noOfPeriodPerWeek').disable();
          }
          if (!obj.isChecked) {
            item.get('noOfPeriodPerWeek').disable();
          }

          academicLevels.push(item);
        });
      }, error => {

      });
  }

  getEmptySubject() {
    this.subjectService.getEmptySubject().subscribe(response => {
      this.subject = response;
      this.parentSubjects = response.parentSubjects;
      let academicLevels = this.form.get("academicLevels") as FormArray;
      response.academicLevels.forEach(obj => {

        let item = new FormGroup({
          id: new FormControl(obj.id),
          description: new FormControl(obj.description),
          isChecked: new FormControl(obj.isChecked),
          noOfPeriodPerWeek: new FormControl(obj.noOfPeriodPerWeek)
        });

        item.get('noOfPeriodPerWeek').disable();
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
    let sb = this.form.getRawValue() as SubjectModel;
    console.log(sb);
    this.eventService.subjectSaved(sb);
  }

  cancel() {
    this.modalRef.hide();
  }

  getControlLabel(type: string) {
    return this.form.controls[type].value;
  }

  checkedChange(isChecked: boolean, row: FormGroup) {
    if (isChecked) {
      row.get('noOfPeriodPerWeek').enable();
    }
    else {
      row.get('noOfPeriodPerWeek').setValue(0);
      row.get('noOfPeriodPerWeek').disable();
    }
  }

  isParentChanged(e) {

    if (this.booleanSelection[e.target.selectedIndex].value === true) {
      this.form.get('isBasketSubject').setValue(false);
      this.form.get('isBasketSubject').disable();

      this.form.get('parentSubjectId').setValue(0);
      this.form.get('parentSubjectId').disable();
    }
    else {

      //this.form.get('parentSubjectId').enable();
      this.form.get('isBasketSubject').setValue(false);
      this.form.get('isBasketSubject').enable();
      this.form.get('parentSubjectId').disable();

    }

    this.getAcademicLevelDetailsForSelectedSubject(0);
  }

  parentSubjectChanged(e) {
    let selectedParentSubjectId = this.parentSubjects[e.target.selectedIndex].id;
    this.getAcademicLevelDetailsForSelectedSubject(selectedParentSubjectId);
  }

  getAcademicLevelDetailsForSelectedSubject(id: number) {
    this.subjectService.getAcademicLevelDetailForSelectedSubject(id)
      .subscribe(response => {

        let academicLevels = this.form.get("academicLevels") as FormArray;
        academicLevels.clear();
        response.forEach(obj => {

          let item = new FormGroup({
            id: new FormControl(obj.id),
            description: new FormControl(obj.description),
            isChecked: new FormControl(obj.isChecked),
            noOfPeriodPerWeek: new FormControl(obj.noOfPeriodPerWeek)
          });

          if (!this.isParentSubject && this.isBasketSubject) {
            item.get('noOfPeriodPerWeek').disable();
            item.get('isChecked').disable();
          }

          if (!obj.isChecked) {
            item.get('noOfPeriodPerWeek').disable();
          }

          academicLevels.push(item);
        });

      }, error => {

      });
  }

  isBasketSubjectChanged(e) {

    if (this.booleanSelection[e.target.selectedIndex].value === true) {

      this.form.get('parentSubjectId').enable();
    }
    else {

      this.form.get('parentSubjectId').setValue(0);
      this.form.get('parentSubjectId').disable();

    }

    this.getAcademicLevelDetailsForSelectedSubject(0);

  }

  get academicLevels() {
    return this.form.get("academicLevels") as FormArray;
  }

  get isParentSubject(): boolean {
    return this.form.get('isParentBasketSubject').value;
  }

  get isBasketSubject(): boolean {
    return this.form.get('isBasketSubject').value;
  }

}