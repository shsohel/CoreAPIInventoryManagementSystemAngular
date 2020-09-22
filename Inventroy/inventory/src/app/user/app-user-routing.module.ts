import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { UserCreateRequestComponent } from './components/user-create-request/user-create-request.component';
import { UserCreateRequestListComponent } from './components/user-create-request-list/user-create-request-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';

const routes: Routes = [
  { path: "signup", component: SignupComponent },
  { path: "forgotPassword", component: ForgotPasswordComponent },
  { path: "resetPassword", component: ResetPasswordComponent },
  { path: "createUser", component: UserCreateRequestComponent },
  { path: "createUser/:id", component: UserCreateRequestComponent },
  { path: "createUserRequestList", component: UserCreateRequestListComponent },
  { path: "userList", component: UserListComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppUserRoutingModule { }
