import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPayIncentiveComponent } from './components/pay-incentive/add-pay-incentive/add-pay-incentive.component';
import { PayIncentiveListComponent } from './components/pay-incentive/pay-incentive-list/pay-incentive-list.component';
import { PayIncentiveDetailsComponent } from './components/pay-incentive/pay-incentive-details/pay-incentive-details.component';

const routes: Routes = [
  { path: "addPayIncentive", component: AddPayIncentiveComponent},
  { path: "addPayIncentive/:id", component: AddPayIncentiveComponent},
  { path: "payIncentiveList", component: PayIncentiveListComponent},
  { path: "payIncentiveDetails/:id", component: PayIncentiveDetailsComponent},
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class IncentiveRoutingModule { }