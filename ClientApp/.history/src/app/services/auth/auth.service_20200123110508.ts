import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LoginModel } from '../../models/account/login.model';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login(loginModel: LoginModel): Observable<any> {
    return this.httpClient.post<any>(environment.apiUrl + 'Auth/login', loginModel);
  }

  isLoggedInUser() {
    const userSession = localStorage.getItem('currentUser');
    if (userSession) {
      return true;
    } else {
      return false;
    }
  }

  signOut() {
    const userSession = localStorage.getItem('currentUser');
    if (userSession) {
      localStorage.removeItem('currentUser');
    }
  }
}
