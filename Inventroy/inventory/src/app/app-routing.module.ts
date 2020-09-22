import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './common/components/auth/auth.guard';
import { LoginComponent } from './user/components/login/login.component';


const routes: Routes = [
  { path: '', loadChildren: "./common/app-common.module#AppCommonModule" },
  { path: "user/login", component: LoginComponent },
  // {path: 'test', component: AlertComponent},
  // {path: 'home',
  // loadChildren: "./home/home.module#HomeModule"},
  // {path: 'addmission',
  // loadChildren: "./addmission/addmission.module#AddmissionModule"},
  // {path: 'education',
  // loadChildren: "./education/education.module#EducationModule"},
  // {path: "examination",
  // loadChildren: "./examination/examination.module#ExaminationModule"},
  // {path: "finance",
  // loadChildren: "./finance/finance.module#FinanceModule"},
  // {
  //   path: "administration",
  //   loadChildren: "./administration/administration.module#AdministrationModule", canActivate: [AuthGuard]
  // },
  { path: 'administration', loadChildren: () => import('./administration/administration.module').then(m => m.AdministrationModule) },
  {
    path: "sale",
    loadChildren: "./sale/sale.module#SaleModule", canActivate: [AuthGuard]
  },
  {
    path: "finance",
    loadChildren: "./finance/finance.module#FinanceModule", canActivate: [AuthGuard]
  },
  {
    path: "purchase",
    loadChildren: "./purchase/purchase.module#PurchaseModule", canActivate: [AuthGuard]
  },
  {
    path: "expense",
    loadChildren: "./expense/expense.module#ExpenseModule", canActivate: [AuthGuard]
  },
  {
    path: "incentive",
    loadChildren: "./incentive/incentive.module#IncentiveModule", canActivate: [AuthGuard]
  },
  {
    path: "stock",
    loadChildren: "./stock/stock.module#StockModule", canActivate: [AuthGuard]
  },
  {
    path: "user",
    loadChildren: "./user/app-user.module#AppUserModule"
  },
  { path: '**', redirectTo: '/user/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
