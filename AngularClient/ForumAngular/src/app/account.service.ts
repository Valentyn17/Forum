import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from './models/User';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  readonly BaseURI = 'http://localhost:49414';
  user: User;
  userToCheck: User;
  roles: string[]=[];

  constructor(private fb:FormBuilder,
     private http:HttpClient, 
     private router:Router, 
     private toastr:ToastrService,
     private cookieService: CookieService) {

  }

  formModel = this.fb.group({
    Email:['', [Validators.email, Validators.required]],
    FirstName:['', Validators.required],
    LastName:['', Validators.required],
    DateOfBirth:['', Validators.required],
    Passwords: this.fb.group({
      Password:['', [Validators.required, Validators.minLength(5)]],
      PasswordConfirm:['', [Validators.required, Validators.minLength(5)]], 
    })
  })

  getUserList():Observable<any[]>{
    return this.http.get<any>(this.BaseURI+'/Account/getUsers');
  }
  deleteUser(val: any){
    return this.http.delete(this.BaseURI+'/Account/deleteUserById/'+ val);
  }
  register() {
    var body = {
      FirstName: this.formModel.value.Name,
      LastName: this.formModel.value.Name,
      DateOfBirth: this.formModel.value.Name,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
      PasswordConfirm: this.formModel.value.Passwords.PasswordConfirm
    };
    
    return this.http.post(this.BaseURI + '/Account/register', body);
  }

  login(formData: any) {
    return this.http.post(this.BaseURI + '/Account/login', formData, {responseType: 'text'}).subscribe(
      response=>{
      localStorage.setItem('token', response);
      this.user = this.getUser(response);
      this.router.navigateByUrl('');
      },
      (error:HttpErrorResponse) => {
        this.toastr.error('Invalid password or email', 'Error');
      });
  }

  ifLoggedIn():boolean {
    if(localStorage.getItem('token')!==null){
      return true;
    }
    return false;
  }

  ifAdmin():boolean{
    var token=localStorage.getItem('token');
    if(token==null) return false;
    else
    {
      this.userToCheck= this.getUser(token);
      console.log(this.userToCheck)
      this.roles=this.userToCheck.role;
      console.log(this.roles);
      if(this.roles.includes('admin'))
      {
      return true;
      }
      return false;
    }
    
  }
  signOut() {
    localStorage.removeItem('token');
    this.user=new User([],'');
    this.router.navigate(['']);
  }

  getUserByEmail(email: any)
  {
    return this.http.get(this.BaseURI + '/Account/getUserByEmail', email);
  }

  public getUser(token:string):User {
    let a = JSON.parse(atob(token.split('.')[1]))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    console.log(a);
    let b = JSON.parse(atob(token.split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]
    return new User(a, b);    
  }
}