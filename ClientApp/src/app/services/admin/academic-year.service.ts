import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AcademicYearPaginatedItemsModel } from '../../models/master/academic-year/academic-year-paginated-item.model';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AcademicYearModel } from '../../models/master/academic-year/academic-year.model';
import { ResponseModel } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class AcademicYearService {

  constructor(private httpClient: HttpClient) { }

  getAllAcademicYearClassDetails(currentPage: number, pageSize: number, sortBy: string): Observable<AcademicYearPaginatedItemsModel> {
    return this.httpClient.
      get<AcademicYearPaginatedItemsModel>(environment.apiUrl + 'AcademicYear/GetAllAcademicYearClassDetails?currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getSelectedAcademicYearClassDetailById(id: number): Observable<AcademicYearModel> {
    return this.httpClient.get<AcademicYearModel>(environment.apiUrl + 'AcademicYear/GetSelectedAcademicYearClassDetailById/' + id);
  }



  saveAcademicYear(model: AcademicYearModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'AcademicYear/SaveAcademicYear', model);
  }

  updateAcademicYear(model: AcademicYearModel): Observable<ResponseModel> {
    return this.httpClient.
      put<ResponseModel>(environment.apiUrl + 'AcademicYear/UpdateAcademicYear', model);
  }

  deleteAcademivYear(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'AcademicYear/DeleteAcademivYear/' + id);
  }
}
