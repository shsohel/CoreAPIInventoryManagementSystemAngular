import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './common/module/material.module';
import { AppCommonModule } from './common/app-common.module';
import { AppMatDialogComponent } from './common/components/app-mat-dialog/app-mat-dialog.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './common/components/auth/auth.interceptor';
import { LoginComponent } from './user/components/login/login.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
//import {MatRadioModule} from '@angular/material/radio';

@NgModule({
  declarations: [
    AppComponent,
    AppMatDialogComponent, LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AppCommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    //MatRadioModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
  entryComponents: [AppMatDialogComponent]
})
export class AppModule { }
