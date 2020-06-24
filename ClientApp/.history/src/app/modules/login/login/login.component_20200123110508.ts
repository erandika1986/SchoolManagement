import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

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
    private ngxSpinnerService: NgxSpinnerService) { }

  ngOnInit() {
  }

}
