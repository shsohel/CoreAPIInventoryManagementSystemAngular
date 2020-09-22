import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddFixedExpenseComponent } from './components/fixed-expense/add-fixed-expense/add-fixed-expense.component';
import { FixedExpenseListComponent } from './components/fixed-expense/fixed-expense-list/fixed-expense-list.component';
import { FixedExpenseDetailsComponent } from './components/fixed-expense/fixed-expense-details/fixed-expense-details.component';
import { AddGeneralExpenseComponent } from './components/general-expense/add-general-expense/add-general-expense.component';
import { GeneralExpenseListComponent } from './components/general-expense/general-expense-list/general-expense-list.component';
import { GeneralExpenseDetailsComponent } from './components/general-expense/general-expense-details/general-expense-details.component';
import { AddSalaryPaymentComponent } from './components/salary-payment/add-salary-payment/add-salary-payment.component';
import { SalaryPaymentListComponent } from './components/salary-payment/salary-payment-list/salary-payment-list.component';
import { SalaryPaymentDetailsComponent } from './components/salary-payment/salary-payment-details/salary-payment-details.component';
import { FixedExpenseSettingDetailsComponent } from './components/fixed-expense-setting/fixed-expense-setting-details/fixed-expense-setting-details.component';
import { FixedExpenseSettingListComponent } from './components/fixed-expense-setting/fixed-expense-setting-list/fixed-expense-setting-list.component';
import { AddFixedExpenseSettingComponent } from './components/fixed-expense-setting/add-fixed-expense-setting/add-fixed-expense-setting.component';
import { AddExpenseTypeComponent } from './components/expense-Type/add-expense-type/add-expense-type.component';
import { ExpenseTypeListComponent } from './components/expense-Type/expense-type-list/expense-type-list.component';
import { ExpenseTypeDetailsComponent } from './components/expense-Type/expense-type-details/expense-type-details.component';
import { AddExpenseHeadComponent } from './components/expense-head/add-expense-head/add-expense-head.component';
import { ExpenseHeadListComponent } from './components/expense-head/expense-head-list/expense-head-list.component';
import { ExpenseHeadDetailsComponent } from './components/expense-head/expense-head-details/expense-head-details.component';

const routes: Routes = [
  { path: "addFixedExpense", component: AddFixedExpenseComponent},
  { path: "addFixedExpense/:id", component: AddFixedExpenseComponent},
  { path: "fixedExpenseList", component: FixedExpenseListComponent},
  { path: "fixedExpenseDetails/:id", component: FixedExpenseDetailsComponent},  
  { path: "addFixedExpenseSetting", component: AddFixedExpenseSettingComponent},
  { path: "addFixedExpenseSetting/:id", component: AddFixedExpenseSettingComponent},
  { path: "fixedExpenseSettingList", component: FixedExpenseSettingListComponent},
  { path: "fixedExpenseSettingDetails/:id", component: FixedExpenseSettingDetailsComponent},
  { path: "addGeneralExpense", component: AddGeneralExpenseComponent},
  { path: "addGeneralExpense/:id", component: AddGeneralExpenseComponent},
  { path: "generalExpenseList", component: GeneralExpenseListComponent},
  { path: "generalExpenseDetails/:id", component: GeneralExpenseDetailsComponent},
  { path: "addSalaryPayment", component: AddSalaryPaymentComponent},
  { path: "addSalaryPayment/:id", component: AddSalaryPaymentComponent},
  { path: "salaryPaymentList", component: SalaryPaymentListComponent},
  { path: "salaryPaymentDetails/:id", component: SalaryPaymentDetailsComponent},  
  { path: "addExpenseType", component: AddExpenseTypeComponent},
  { path: "addExpenseType/:id", component: AddExpenseTypeComponent},
  { path: "expenseTypeList", component: ExpenseTypeListComponent},
  { path: "expenseTypeDetails/:id", component: ExpenseTypeDetailsComponent},
  { path: "addExpenseHead", component: AddExpenseHeadComponent},
  { path: "addExpenseHead/:id", component: AddExpenseHeadComponent},
  { path: "expenseHeadList", component: ExpenseHeadListComponent},
  { path: "expenseHeadDetails/:id", component: ExpenseHeadDetailsComponent},   
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ExpenseRoutingModule { }