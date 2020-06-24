import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { HttpHandler, HttpRequest, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService {

  constructor(private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private authService: AuthService,
    public router: Router) { }

    intercept(req: HttpRequest<any>,
      next: HttpHandler): Observable<HttpEvent<any>> {
      const idToken = localStorage.getItem('currentUser');
      if (idToken) {
        const token: string = 'Bearer ' + JSON.parse(idToken).token;
        const cloned = req.clone({
          setHeaders: { Authorization: token }
        });
        return next.handle(cloned).pipe(map((event: HttpEvent<any>) => {
          if (event instanceof HttpResponse) {
          }
          return event;
        }),
          catchError((error: HttpErrorResponse) => {
            if (error.status === 401) {
              this.authService.signOut();
              this.toastrService.error('UnAuthorized user attempt. Please login with valid credentials.', '401 Unauthorized');
              this.router.navigate(['']);
            }
            return throwError(error);
          }));
      } else {
        return next.handle(req).pipe(map((event: HttpEvent<any>) => {
          if (event instanceof HttpResponse) {
          }
          return event;
        }),
          catchError((error: HttpErrorResponse) => {
            if (error.status === 401) {
              this.authService.signOut();
              this.toastrService.error('UnAuthorized user attempt. Please login with valid credentials.', '401 Unauthorized');
              this.router.navigate(['']);
            }
            return throwError(error);
          }));
      }
    }
}
