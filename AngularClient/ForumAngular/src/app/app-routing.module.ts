import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { MessageComponent } from './message/message.component';
import { RegistrationComponent } from './registration/registration.component';
import { SectionComponent } from './section/section.component';
import { TopicComponent } from './topic/topic.component';
import { UserComponent } from './user/user.component';
const routes: Routes = [
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  {path: 'section', component: SectionComponent },
  {  path: 'section/:id/topic',  component: TopicComponent},
  {  path: 'section/:id/topic/:topicid',  component: MessageComponent},
  { path: 'user', component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
