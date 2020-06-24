import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassNameComponent } from './class-name.component';

describe('ClassNameComponent', () => {
  let component: ClassNameComponent;
  let fixture: ComponentFixture<ClassNameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClassNameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
