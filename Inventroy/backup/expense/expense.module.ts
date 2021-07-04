import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { AppCommonModule } from '../common/app-common.module';
import { ExpenseRoutingModule } from './expense-routing.module';
import { FixedExpenseService } from './services/fixed-expense.service';
import { AddFixedExpenseComponent } from './components/fixed-expense/add-fixed-expense/add-fixed-expense.component';
import { FixedExpenseDetailsComponent } from './components/fixed-expense/fixed-expense-details/fixed-expense-details.component';
import { FixedExpenseListComponent } from './components/fixed-expense/fixed-expense-list/fixed-expense-list.component';
import { AddGeneralExpenseComponent } from './components/general-expense/add-general-expense/add-general-expense.component';
import { GeneralExpenseListComponent } from './components/general-expense/general-expense-list/general-expense-list.component';
import { GeneralExpenseDetailsComponent } from './components/general-expense/general-expense-details/general-expense-details.component';
import { GeneralExpenseService } from './services/general-expense.service';
import { AddSalaryPaymentComponent } from './components/salary-payment/add-salary-payment/add-salary-payment.component';
import { SalaryPaymentListComponent } from './components/salary-payment/salary-payment-list/salary-payment-list.component';
import { SalaryPaymentDetailsComponent } from './components/salary-payment/salary-payment-details/salary-payment-details.component';
import { SalaryPaymentService } from './services/salary-payment.service';
import { AddFixedExpenseSettingComponent } from './components/fixed-expense-setting/add-fixed-expense-setting/add-fixed-expense-setting.component';
import { FixedExpenseSettingListComponent } from './components/fixed-expense-setting/fixed-expense-setting-list/fixed-expense-setting-list.component';
import { FixedExpenseSettingDetailsComponent } from './components/fixed-expense-setting/fixed-expense-setting-details/fixed-expense-setting-details.component';
import { FixedExpenseSettingService } from './services/fixed-expense-setting.service';
import { AddExpenseTypeComponent } from './components/expense-Type/add-expense-type/add-expense-type.component';
import { ExpenseTypeDetailsComponent } from './components/expense-Type/expense-type-details/expense-type-details.component';
import { ExpenseTypeListComponent } from './components/expense-Type/expense-type-list/expense-type-list.component';
import { ExpenseTypeService } from './services/expense-type.service';
import { AddExpenseHeadComponent } from './components/expense-head/add-expense-head/add-expense-head.component';
import { ExpenseHeadListComponent } from './components/expense-head/expense-head-list/expense-head-list.component';
import { ExpenseHeadDetailsComponent } from './components/expense-head/expense-head-details/expense-head-details.component';
import { ExpenseHeadService } from './services/expense-head.service';

@NgModule({
  declarations: [
      AddFixedExpenseComponent,
      FixedExpenseDetailsComponent,
      FixedExpenseListComponent,
      AddGeneralExpenseComponent,
      GeneralExpenseListComponent,
      GeneralExpenseDetailsComponent,
      AddSalaryPaymentComponent,
      SalaryPaymentListComponent,
      SalaryPaymentDetailsComponent,
      AddFixedExpenseSettingComponent,
      FixedExpenseSettingListComponent,
      FixedExpenseSettingDetailsComponent,
      AddExpenseTypeComponent,
      ExpenseTypeDetailsComponent,
      ExpenseTypeListComponent,
      AddExpenseHeadComponent,
      ExpenseHeadListComponent,
      ExpenseHeadDetailsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    ExpenseRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule,    
  ],
  providers:[
    DataService,
    FixedExpenseService,
    GeneralExpenseService,
    SalaryPaymentService,
    FixedExpenseSettingService,
    ExpenseTypeService,
    ExpenseHeadService
  ]
})
export class ExpenseModule { }