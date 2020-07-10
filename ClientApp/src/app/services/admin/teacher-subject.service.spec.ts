import { TestBed } from '@angular/core/testing';

import { TeacherSubjectService } from './teacher-subject.service';

describe('TeacherSubjectService', () => {
  let service: TeacherSubjectService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeacherSubjectService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
