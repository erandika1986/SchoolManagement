import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UserModel } from '../../models/account/user.model';
import { ResponseModel } from '../../models/common/response.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getUserList(name: string, roleId: string,
    currentPage: number, pageSize: number, sortBy: string): Observable<UserModel> {
    return this.httpClient.
    get<UserModel>(environment.apiUrl + 'User/GetUserList/'
    + name + '/' + roleId + '/' + currentPage + '/' + pageSize + '/' + sortBy);
  }

  saveUser(user: UserModel): Observable<ResponseModel> {
    return this.httpClient.
    post<ResponseModel>(environment.apiUrl + 'User/SaveUser', user);
  }

  deleteUser(id: number): Observable<ResponseModel> {
    return this.httpClient.
    delete<ResponseModel>(environment.apiUrl + 'User/DeleteUser/' + id);
  }
}
