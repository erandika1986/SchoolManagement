import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassNameDialogComponent } from './class-name-dialog.component';

describe('ClassNameDialogComponent', () => {
  let component: ClassNameDialogComponent;
  let fixture: ComponentFixture<ClassNameDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClassNameDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassNameDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
