import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditUserPopUpComponent } from './add-edit-user-pop-up.component';

describe('AddEditUserPopUpComponent', () => {
  let component: AddEditUserPopUpComponent;
  let fixture: ComponentFixture<AddEditUserPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditUserPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditUserPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
