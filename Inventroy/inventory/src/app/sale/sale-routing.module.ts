import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AddCustomerComponent } from './components/customer/add-customer/add-customer.component';
import { CustomerListComponent } from './components/customer/customer-list/customer-list.component';
import { CustomerDetailsComponent } from './components/customer/customer-details/customer-details.component';
import { AddVendorComponent } from './components/vendor/add-vendor/add-vendor.component';
import { VendorListComponent } from './components/vendor/vendor-list/vendor-list.component';
import { VendorDetailsComponent } from './components/vendor/vendor-details/vendor-details.component';

const routes: Routes = [
  { path: "addCustomer", component:  AddCustomerComponent},
  { path: "addCustomer/:id", component:  AddCustomerComponent},
  { path: "customerList", component:  CustomerListComponent},
  { path: "customerDetails/:id", component:  CustomerDetailsComponent},
  { path: "addVendor", component:  AddVendorComponent},
  { path: "addVendor/:id", component:  AddVendorComponent},
  { path: "vendorList", component:  VendorListComponent},
  { path: "vendorDetails/:id", component:  VendorDetailsComponent}
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class SaleRoutingModule { }
