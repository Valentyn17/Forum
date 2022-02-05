import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from './models/User';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  readonly BaseURI = 'https://localhost:44356';
  user: User;

  constructor(private fb:FormBuilder, private http:HttpClient, private router:Router, private toastr:ToastrService) {

  }

  formModel = this.fb.group({
    Email:['', [Validators.email, Validators.required]],
    Name:['', Validators.required],
    Passwords: this.fb.group({
      Password:['', [Validators.required, Validators.minLength(5)]],
      PasswordConfirm:['', [Validators.required, Validators.minLength(5)]], 
    })
  })

  register() {
    var body = {
      Name: this.formModel.value.Name,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
      PasswordConfirm: this.formModel.value.Passwords.PasswordConfirm
    };
    
    return this.http.post(this.BaseURI + '/account/register', body);
  }

  login(formData: any) {
    return this.http.post(this.BaseURI + '/account/login', formData, {responseType: 'text'}).subscribe(
      response=>{
      localStorage.setItem('token', response);
      this.user = this.getUser(response);
      this.router.navigateByUrl('');
      },
      (error:HttpErrorResponse) => {
        this.toastr.error('Invalid password or email', 'Error');
      });;
  }

  public getUser(token:string):User {
    let a = JSON.parse(atob(token.split('.')[1]))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    let b = JSON.parse(atob(token.split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]
    return new User(a, b);    
  }
}