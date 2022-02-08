import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public service:AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {

    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe({
      complete: () => {
        this.service.formModel.reset();
        this.toastr.success('New user created!', 'Registration successful.');
      }, 
      error: () => {
        this.toastr.error('Username is already taken','Registration failed.');
      }  
    }
    );

  }

}
