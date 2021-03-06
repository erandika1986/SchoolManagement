import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ClassSubjectTeacherPaginatedItemsModel } from '../../models/master/class-subject-teacher/class.subject.teacher.paginated.item.model';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ClassSubjectTeacherModel } from '../../models/master/class-subject-teacher/class-subject-teacher.model';
import { ClassSubjectTeacherMasterDataModel } from '../../models/master/class-subject-teacher/class.subject.teacher.master.data.model';
import { ResponseModel } from '../../models/common/response.model';
import { DropDownModel } from '../../models/common/drop-down.model';

@Injectable({
  providedIn: 'root'
})
export class ClassTeacherService {

  onNewRecordAdded: Subject<any>;

  constructor(private httpClient: HttpClient) {
    this.onNewRecordAdded = new Subject();
  }

  getAllSubjectClassTeachers(currentPage: number, pageSize: number, sortBy: string, academicYearId: number, academicLevelId: number): Observable<ClassSubjectTeacherPaginatedItemsModel> {
    return this.httpClient.get<ClassSubjectTeacherPaginatedItemsModel>(environment.apiUrl + 'ClassSubjectTeacher/getAllSubjectClassTeachers', {
      params: new HttpParams()
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
        .set('sortBy', sortBy)
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
    });
  }

  getClassesForSelectedAcademicYearAndAcademicLevel(academicYearId: number, academicLevelId: number): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'ClassSubjectTeacher/getClassesForSelectedAcademicYearAndAcademicLevel', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
    });
  }


  validateClassTeacher(academicYearId: number, academicLevelId: number, classNameId: number, teacherId: number): Observable<ResponseModel> {
    return this.httpClient.get<ResponseModel>(environment.apiUrl + 'ClassSubjectTeacher/validateClassTeacher', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('classNameId', classNameId.toString())
        .set('teacherId', teacherId.toString())
    });
  }

  validateAssignedSubjectTeacher(academicYearId: number, academicLevelId: number, classNameId: number, subjectId: number, teacherId: number): Observable<ResponseModel> {
    return this.httpClient.get<ResponseModel>(environment.apiUrl + 'ClassSubjectTeacher/validateAssignedSubjectTeacher', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('classNameId', classNameId.toString())
        .set('subjectId', subjectId.toString())
        .set('teacherId', teacherId.toString())
    });
  }

  getSelectedSubjectClassTeacherDetails(academicYearId: number, academicLevelId: number, classNameId: number, classCategory: number): Observable<ClassSubjectTeacherModel> {
    return this.httpClient.get<ClassSubjectTeacherModel>(environment.apiUrl + 'ClassSubjectTeacher/getSelectedSubjectClassTeacherDetails', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('classNameId', classNameId.toString())
        .set('classCategory', classCategory.toString())
    });
  }

  getAcademicLevelSubjects(selectedAcademicLevelId: number): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'ClassSubjectTeacher/getAcademicLevelSubjects', {
      params: new HttpParams()
        .set('selectedAcademicLevelId', selectedAcademicLevelId.toString())
    });
  }

  getClassSubjectTeacherMasterData(): Observable<ClassSubjectTeacherMasterDataModel> {
    return this.httpClient.get<ClassSubjectTeacherMasterDataModel>(environment.apiUrl + 'ClassSubjectTeacher/getClassSubjectTeacherMasterData');
  }

  getClassUnAssignedTeachers(): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'ClassSubjectTeacher/getClassUnAssignedTeachers');
  }

  saveClassSubjectTeacherDetails(model: ClassSubjectTeacherModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(environment.apiUrl + 'ClassSubjectTeacher/saveClassSubjectTeacherDetails', model);
  }

  deleteClassSubjectTeacher(academicYearId: number, academicLevelId: number, classNameId: number): Observable<ResponseModel> {
    return this.httpClient.delete<ResponseModel>(environment.apiUrl + 'ClassSubjectTeacher/deleteClassSubjectTeacher', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('classNameId', classNameId.toString())
    });
  }
}
