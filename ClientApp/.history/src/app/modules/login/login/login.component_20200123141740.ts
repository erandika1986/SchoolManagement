import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../services/auth/auth.service';
import { Router } from '@angular/router';
import { FormValidatorService } from '../../../services/common/form-validator.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    schoolName: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private authService: AuthService,
    public router: Router,
    private formValidatorService: FormValidatorService) { }

  ngOnInit() {
  }

  onLoggedin() {
    console.log(this.loginForm.value);
    if (!this.loginForm.valid) {
        this.formValidatorService.validateAllFormFields(this.loginForm);
    } else {
        this.ngxSpinnerService.show();
        this.authService.login(this.loginForm.value)
            .subscribe(response => {
                this.ngxSpinnerService.hide();
                if (response && response.token) {
                    localStorage.setItem('currentUser', JSON.stringify(response));
                    localStorage.setItem('isLoggedin', 'true');
                    this.router.navigate(['/']);
                } else {
                    this.toastrService.error('Please check your username and password are correct', 'Login Failed');
                }
            }, error => {
                this.ngxSpinnerService.hide();
                this.toastrService.error('Please check your username and password are correct', 'Login Failed');
            });
    }
  }


  get schoolName() {
    return this.loginForm.get('schoolName');
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }

}
