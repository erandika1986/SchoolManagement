import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditClassNameDialogComponent } from './add-edit-class-name-dialog.component';

describe('AddEditClassNameDialogComponent', () => {
  let component: AddEditClassNameDialogComponent;
  let fixture: ComponentFixture<AddEditClassNameDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditClassNameDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditClassNameDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
