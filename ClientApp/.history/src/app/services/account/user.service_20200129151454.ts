import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UserModel } from '../../models/account/user.model';
import { ResponseModel } from '../../models/common/response.model';
import { UserPaginatedItemsModel } from '../../models/account/user-paginated-items.model';
import { UserMasterData } from '../../models/account/user-master-data.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getUserList(name: string, roleId: number,
    currentPage: number, pageSize: number, sortBy: string): Observable<UserPaginatedItemsModel> {
    return this.httpClient.
    get<UserPaginatedItemsModel>(environment.apiUrl + 'User/GetUserList?name='
    + name + '&roleId=' + roleId + '&currentPage=' + currentPage + '&pageSize=' + pageSize + '&sortBy=' + sortBy);
  }

  getUserById(id: number): Observable<UserModel> {
    return this.httpClient.get<UserModel>(environment.apiUrl + 'User/GetUserById/' + id);
  }

  saveUser(user: UserModel): Observable<ResponseModel> {
    return this.httpClient.
    post<ResponseModel>(environment.apiUrl + 'User/SaveUser', user);
  }

  updateUser(user: UserModel): Observable<ResponseModel> {
    return this.httpClient.
      put<ResponseModel>(environment.apiUrl + 'User/UpdateUser', user);
  }

  deleteUser(id: number): Observable<ResponseModel> {
    return this.httpClient.
    delete<ResponseModel>(environment.apiUrl + 'User/DeleteUser/' + id);
  }

  getUserMasterData(): Observable<UserMasterData> {
    return this.httpClient.get<UserMasterData>(environment.apiUrl + 'User/GetUserMasterData');
  }
}
