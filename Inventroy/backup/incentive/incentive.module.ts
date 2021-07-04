import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { AppCommonModule } from '../common/app-common.module';
import { MatRadioModule } from '@angular/material/radio';
import { IncentiveRoutingModule } from './incentive-routing.module';
import { PayIncentiveService } from './services/pay-incentive.service';
import { AddPayIncentiveComponent } from './components/pay-incentive/add-pay-incentive/add-pay-incentive.component';
import { PayIncentiveDetailsComponent } from './components/pay-incentive/pay-incentive-details/pay-incentive-details.component';
import { PayIncentiveListComponent } from './components/pay-incentive/pay-incentive-list/pay-incentive-list.component';
import { EmployeeService } from '../administration/services/employee.service';
import { AdministrationModule } from '../administration/administration.module';


@NgModule({
  declarations: [
    AddPayIncentiveComponent,
    PayIncentiveDetailsComponent,
    PayIncentiveListComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    IncentiveRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule,   
    MatRadioModule,
    AdministrationModule
  ],
  providers:[
    DataService,
    PayIncentiveService,
    EmployeeService
  ]
})
export class IncentiveModule { }