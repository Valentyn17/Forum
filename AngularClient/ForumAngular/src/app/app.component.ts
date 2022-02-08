import { Component, OnInit } from '@angular/core';
import { User } from './models/User';
import { AccountService } from './account.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ForumAngular';
  ifLoggedIn = false;
  constructor(public AccountService: AccountService) {
  }
  


  ngOnInit(): void {
    this.ifLoggedIn = this.AccountService.ifLoggedIn();
  }
  refresh(){
    window.location.reload();
  }

  signOut(){
    this.AccountService.signOut();
    this.refresh();
  }
}
