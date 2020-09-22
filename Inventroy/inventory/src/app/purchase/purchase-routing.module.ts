import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddSupplierComponent } from './components/supplier/add-supplier/add-supplier.component';
import { SupplierListComponent } from './components/supplier/supplier-list/supplier-list.component';
import { SupplierDetailsComponent } from './components/supplier/supplier-details/supplier-details.component';
import { PurchaseDetailsComponent } from './components/purchase/purchase-details/purchase-details.component';
import { PurchaseListComponent } from './components/purchase/purchase-list/purchase-list.component';
import { AddPurchaseComponent } from './components/purchase/add-purchase/add-purchase.component';

const routes: Routes = [
  { path: "addSupplier", component: AddSupplierComponent},
  { path: "addSupplier/:id", component: AddSupplierComponent},
  { path: "supplierList", component: SupplierListComponent},
  { path: "supplierDetails/:id", component: SupplierDetailsComponent},
  { path: "addPurchase", component: AddPurchaseComponent},
  { path: "addPurchase/:id", component: AddPurchaseComponent},
  { path: "purchaseList", component: PurchaseListComponent},
  { path: "purchaseDetails/:id", component: PurchaseDetailsComponent},
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class PurchaseRoutingModule { }