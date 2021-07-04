import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MaterialModule } from './module/material.module';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './components/auth/auth.interceptor';
import { HomeComponent } from './components/home/home.component';
import { AppCommonRoutingModule } from './app-common-routing.module';
import { AppUserManagerService } from '../user/services/app-user-manager.service';
import { DataService } from './services/data.service';
import { AppMessageComponent } from './components/app-message/app-message.component';


@NgModule({
  declarations: [
    MainNavComponent,
    HomeComponent,
    AppMessageComponent
  ],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatListModule,
    MaterialModule,
    RouterModule,
    AppCommonRoutingModule,
    HttpClientModule
  ],
  exports:[
    MainNavComponent,
  ],
  providers: [ AppUserManagerService, DataService,
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ]
})
export class AppCommonModule { }
