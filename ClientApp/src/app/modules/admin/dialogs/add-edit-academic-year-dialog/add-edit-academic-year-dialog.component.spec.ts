import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAcademicYearDialogComponent } from './add-edit-academic-year-dialog.component';

describe('AddEditAcademicYearDialogComponent', () => {
  let component: AddEditAcademicYearDialogComponent;
  let fixture: ComponentFixture<AddEditAcademicYearDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditAcademicYearDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAcademicYearDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
