import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AcademicLevelModel } from '../../models/master/academic-level/academic-level.model';
import { ClassNameModel } from '../../models/master/class-name/class-name.model';
import { SubjectModel } from '../../models/master/subject/subject.model';
import { AssessmentTypeModel } from '../../models/master/assessment-type/assessment-type.model';
import { AcademicYearModel } from '../../models/master/academic-year/academic-year.model';

@Injectable()
export class EventService {

    // Observable string sources
    private deleteconfirmedSource = new Subject<number>();
    private academicLevelSavedSource = new Subject<AcademicLevelModel>();
    private classNameSavedSource = new Subject<ClassNameModel>();
    private subjectSavedSource = new Subject<SubjectModel>();
    private assessmentTypeSavedSource = new Subject<AssessmentTypeModel>();
    private academicYearSavedSource = new Subject<AcademicYearModel>();

    // Observable string streams
    deleteconfirmed$ = this.deleteconfirmedSource.asObservable();
    academicLevelSaved$ = this.academicLevelSavedSource.asObservable();
    classNameSaved$ = this.classNameSavedSource.asObservable();
    subjectSaved$ = this.subjectSavedSource.asObservable();
    assessmentTypeSaved$ = this.assessmentTypeSavedSource.asObservable();
    academicYearSaved$ = this.academicYearSavedSource.asObservable();

    deleteconfirmed(id: number) {
        this.deleteconfirmedSource.next(id);
    }

    academicLevelSaved(academicLevel: AcademicLevelModel) {
        this.academicLevelSavedSource.next(academicLevel);
    }

    classNameSaved(className: ClassNameModel) {
        this.classNameSavedSource.next(className);
    }

    subjectSaved(subject: SubjectModel) {
        this.subjectSavedSource.next(subject);
    }

    assessmentTypeSaved(assessmentType: AssessmentTypeModel) {
        this.assessmentTypeSavedSource.next(assessmentType);
    }

    academicYearSaved(academicYear: AcademicYearModel) {
        this.academicYearSavedSource.next(academicYear);
    }

}