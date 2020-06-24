import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { SubjectPaginatedItemsModel } from '../../models/master/subject/subject-paginated-item.model';
import { SubjectModel } from '../../models/master/subject/subject.model';
import { ResponseModel } from '../../models/common/response.model';
import { BasicSubjectModel } from '../../models/master/common/basic-subject.model';
import { BasicAcademicLevel } from '../../models/master/common/basic-academic-level.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private httpClient: HttpClient) { }

  getAllSubjects(currentPage: number, pageSize: number, sortBy: string): Observable<SubjectPaginatedItemsModel> {
    return this.httpClient.
      get<SubjectPaginatedItemsModel>(environment.apiUrl + 'Subject/GetAllSubjects?currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getSubjectById(id: number): Observable<SubjectModel> {
    return this.httpClient.get<SubjectModel>(environment.apiUrl + 'Subject/GetSubjectById/' + id);
  }

  getAcademicLevelDetailForSelectedSubject(id: number): Observable<BasicAcademicLevel[]> {
    return this.httpClient.get<BasicAcademicLevel[]>(environment.apiUrl + 'Subject/GetAcademicLevelDetailForSelectedSubject/' + id);
  }

  getAvailableBasketSubjects(parentSubjectId: number): Observable<BasicSubjectModel[]> {
    return this.httpClient.get<BasicSubjectModel[]>(environment.apiUrl + 'Subject/GetAvailableBasketSubjects/' + parentSubjectId);
  }

  getEmptySubject(): Observable<SubjectModel> {
    return this.httpClient.get<SubjectModel>(environment.apiUrl + 'Subject/GetEmptySubject');
  }

  saveSubject(model: SubjectModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'Subject/SaveSubject', model);
  }

  deleteSubject(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'Subject/DeleteSubject/' + id);
  }
}
