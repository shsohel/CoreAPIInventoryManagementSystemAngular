import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { MaterialModule } from '../common/module/material.module';
import { AppUserRoutingModule } from './app-user-routing.module';
import { UserCreateRequestComponent } from './components/user-create-request/user-create-request.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { AppUserManagerService } from './services/app-user-manager.service';
import { DataService } from '../common/services/data.service';
import { UserCreateRequestListComponent } from './components/user-create-request-list/user-create-request-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';


@NgModule({
  declarations: [
      SignupComponent,
      ForgotPasswordComponent,
      UserCreateRequestComponent,
      UserCreateRequestListComponent,
      UserListComponent,
      ResetPasswordComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    AppUserRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    UserService,
    AppUserManagerService,
    DataService
  ]
})
export class AppUserModule { }
