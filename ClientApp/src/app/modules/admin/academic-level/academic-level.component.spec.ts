import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicLevelComponent } from './academic-level.component';

describe('AcademicLevelComponent', () => {
  let component: AcademicLevelComponent;
  let fixture: ComponentFixture<AcademicLevelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcademicLevelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicLevelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
