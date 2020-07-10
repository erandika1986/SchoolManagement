import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditClassSubjectTeacherDialogComponent } from './add-edit-class-subject-teacher-dialog.component';

describe('AddEditClassSubjectTeacherDialogComponent', () => {
  let component: AddEditClassSubjectTeacherDialogComponent;
  let fixture: ComponentFixture<AddEditClassSubjectTeacherDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditClassSubjectTeacherDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditClassSubjectTeacherDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
