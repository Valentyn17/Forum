import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SectionComponent } from './section/section.component';
import { TopicComponent } from './topic/topic.component';
import { MessageComponent } from './message/message.component';
import { SharedService } from './shared.service';
import { AccountService } from './account.service';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ShowSectionComponent } from './section/show-section/show-section.component';
import { AddUpdateSectionComponent } from './section/add-update-section/add-update-section.component';
import { RouterModule } from '@angular/router';
import { AddUpdateTopicComponent } from './topic/add-update-topic/add-update-topic.component';
import { AddUpdateMessageComponent } from './message/add-update-message/add-update-message.component';
import { UserComponent } from './user/user.component';



@NgModule({
  declarations: [
    AppComponent,
    SectionComponent,
    TopicComponent,
    MessageComponent,
    LoginComponent,
    RegistrationComponent,
    ShowSectionComponent,
    AddUpdateSectionComponent,
    AddUpdateTopicComponent,
    AddUpdateMessageComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
