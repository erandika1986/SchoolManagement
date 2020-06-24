import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAcademicLevelDialogComponent } from './add-edit-academic-level-dialog.component';

describe('AddEditAcademicLevelDialogComponent', () => {
  let component: AddEditAcademicLevelDialogComponent;
  let fixture: ComponentFixture<AddEditAcademicLevelDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditAcademicLevelDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAcademicLevelDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
