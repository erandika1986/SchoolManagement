import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeTableListComponent } from './time-table-list.component';

describe('TimeTableListComponent', () => {
  let component: TimeTableListComponent;
  let fixture: ComponentFixture<TimeTableListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimeTableListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeTableListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
