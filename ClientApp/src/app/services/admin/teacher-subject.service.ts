import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AcademicLevelSubjectTeacherAllocationModel } from '../../models/master/subject-teacher/academic.level.subjects.teacher.allocation.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AcademicLevelSubjectTeacherAllocationDetailModel } from '../../models/master/subject-teacher/academic.level.subject.teacher.allocation.detail.model';
import { ResponseModel } from '../../models/common/response.model';
import { DropDownModel } from '../../models/common/drop-down.model';
import { ClassSubjectTeacherMasterDataModel } from '../../models/master/class-subject-teacher/class.subject.teacher.master.data.model';

@Injectable({
  providedIn: 'root'
})
export class TeacherSubjectService {

  constructor(private httpClient: HttpClient) { }

  getClassSubjectTeacherMasterData(): Observable<ClassSubjectTeacherMasterDataModel> {
    return this.httpClient.get<ClassSubjectTeacherMasterDataModel>(environment.apiUrl + 'ClassSubjectTeacher/getClassSubjectTeacherMasterData');
  }

  getAllTeachers(academicYearId: number, academicLevelId: number): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'SubjectTeacher/getAllTeachers');
  }

  getAcademicYearSubjectTeacherAllocation(academicYearId: number, academicLevelId: number): Observable<AcademicLevelSubjectTeacherAllocationModel[]> {
    return this.httpClient.get<AcademicLevelSubjectTeacherAllocationModel[]>(environment.apiUrl + 'SubjectTeacher/getAcademicYearSubjectTeacherAllocation', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
    });
  }

  getSubjectAllocationForSelectedAcademicLevel(academicYearId: number, academicLevelId: number, subjectId: number): Observable<AcademicLevelSubjectTeacherAllocationDetailModel> {
    return this.httpClient.get<AcademicLevelSubjectTeacherAllocationDetailModel>(environment.apiUrl + 'SubjectTeacher/getSubjectAllocationForSelectedAcademicLevel', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('subjectId', subjectId.toString())
    });
  }

  saveSelectedSubjectAllocation(model: AcademicLevelSubjectTeacherAllocationDetailModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(environment.apiUrl + 'SubjectTeacher/saveSelectedSubjectAllocation', model);
  }

  deleteSubjectTeachersAllocationForSelectedLevel(academicYearId: number, academicLevelId: number, subjectId: number): Observable<ResponseModel> {
    return this.httpClient.delete<ResponseModel>(environment.apiUrl + 'SubjectTeacher/deleteSubjectTeachersAllocationForSelectedLevel', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('subjectId', subjectId.toString())
    });
  }

  deleteSubjectTeacherAllocationForSelectedLevel(academicYearId: number, academicLevelId: number, subjectId: number, teacherId: number): Observable<ResponseModel> {
    return this.httpClient.delete<ResponseModel>(environment.apiUrl + 'SubjectTeacher/deleteSubjectTeacherAllocationForSelectedLevel', {
      params: new HttpParams()
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
        .set('subjectId', subjectId.toString())
        .set('teacherId', teacherId.toString())
    });
  }
}
