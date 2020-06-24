import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAssessmentTypeDialogComponent } from './add-edit-assessment-type-dialog.component';

describe('AddEditAssessmentTypeDialogComponent', () => {
  let component: AddEditAssessmentTypeDialogComponent;
  let fixture: ComponentFixture<AddEditAssessmentTypeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditAssessmentTypeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAssessmentTypeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
