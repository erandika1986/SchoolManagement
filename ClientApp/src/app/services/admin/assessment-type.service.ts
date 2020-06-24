import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AssessmentTypePaginatedItemsModel } from '../../models/master/assessment-type/assessment-type-paginated-item.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AssessmentTypeModel } from '../../models/master/assessment-type/assessment-type.model';
import { ResponseModel } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class AssessmentTypeService {

  constructor(private httpClient: HttpClient) { }

  getAllAssessmentTypes(currentPage: number, pageSize: number, sortBy: string): Observable<AssessmentTypePaginatedItemsModel> {
    return this.httpClient.
      get<AssessmentTypePaginatedItemsModel>(environment.apiUrl + 'AssessmentType/GetAllAssessmentTypes?currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getAssessmentTypeById(id: number): Observable<AssessmentTypeModel> {
    return this.httpClient.get<AssessmentTypeModel>(environment.apiUrl + 'AssessmentType/GetAssessmentTypeById/' + id);
  }

  getEmptyAssessmentType(): Observable<AssessmentTypeModel> {
    return this.httpClient.get<AssessmentTypeModel>(environment.apiUrl + 'AssessmentType/GetEmptyAssessmentType');
  }

  saveAssessmentType(model: AssessmentTypeModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'AssessmentType/SaveAssessmentType', model);
  }

  deleteAssessmentType(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'AssessmentType/DeleteAssessmentType/' + id);
  }
}
