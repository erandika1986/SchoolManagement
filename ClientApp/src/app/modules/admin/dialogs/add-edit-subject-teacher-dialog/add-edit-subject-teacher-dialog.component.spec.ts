import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSubjectTeacherDialogComponent } from './add-edit-subject-teacher-dialog.component';

describe('AddEditSubjectTeacherDialogComponent', () => {
  let component: AddEditSubjectTeacherDialogComponent;
  let fixture: ComponentFixture<AddEditSubjectTeacherDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditSubjectTeacherDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSubjectTeacherDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
