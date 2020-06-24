import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ClassNamePaginatedItemsModel } from '../../models/master/class-name/class-name-paginated-item.model';
import { ClassNameModel } from '../../models/master/class-name/class-name.model';
import { ResponseModel } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class ClassNameService {

  constructor(private httpClient: HttpClient) { }

  getAllClassNames(currentPage: number, pageSize: number, sortBy: string): Observable<ClassNamePaginatedItemsModel> {
    return this.httpClient.
      get<ClassNamePaginatedItemsModel>(environment.apiUrl + 'ClassName/GetAllClassNames?currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getClassNameById(id: number): Observable<ClassNameModel> {
    return this.httpClient.get<ClassNameModel>(environment.apiUrl + 'ClassName/GetClassNameById/' + id);
  }



  saveClassName(model: ClassNameModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'ClassName/SaveClassName', model);
  }

  deleteClassName(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'ClassName/DeleteClassName/' + id);
  }
}
