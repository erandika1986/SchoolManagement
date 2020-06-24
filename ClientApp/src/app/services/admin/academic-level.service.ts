import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AcademicLevelPaginatedItemsModel } from '../../models/master/academic-level/academic-level-paginated-items.mode';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AcademicLevelModel } from '../../models/master/academic-level/academic-level.model';
import { ResponseModel } from '../../models/common/response.model';
import { DropDownModel } from '../../models/common/drop-down.model';

@Injectable({
  providedIn: 'root'
})
export class AcademicLevelService {

  constructor(private httpClient: HttpClient) { }

  getAllAcademicLevels(currentPage: number, pageSize: number, sortBy: string): Observable<AcademicLevelPaginatedItemsModel> {
    return this.httpClient.
      get<AcademicLevelPaginatedItemsModel>(environment.apiUrl + 'AcademicLevel/GetAllAcademicLevels?currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getAcademicLevelById(id: number): Observable<AcademicLevelModel> {
    return this.httpClient.get<AcademicLevelModel>(environment.apiUrl + 'AcademicLevel/GetAcademicLevelById/' + id);
  }

  getSchoolHods(): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + 'AcademicLevel/GetSchoolHods');
  }

  saveAcademicLevel(model: AcademicLevelModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'AcademicLevel/SaveAcademicLevel', model);
  }

  deleteAcademivLevel(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'AcademicLevel/DeleteAcademivLevel/' + id);
  }

}
