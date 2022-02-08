import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formModel = {
    Email: '',
    Password: ''
  }

  constructor(private service: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
      if (localStorage.getItem('token') != null)
    {
      this.router.navigateByUrl('');
    }
  }

  onSubmit(form:NgForm): void {
    this.service.login(form.value);
  }
}
