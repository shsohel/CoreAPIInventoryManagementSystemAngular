import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AddCustomerComponent } from './components/customer/add-customer/add-customer.component';
import { CustomerListComponent } from './components/customer/customer-list/customer-list.component';
import { CustomerDetailsComponent } from './components/customer/customer-details/customer-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerService } from './services/customer.service';
import { DataService } from '../common/services/data.service';
import { AddVendorComponent } from './components/vendor/add-vendor/add-vendor.component';
import { SaleRoutingModule } from './sale-routing.module';
import { VendorDetailsComponent } from './components/vendor/vendor-details/vendor-details.component';
import { VendorListComponent } from './components/vendor/vendor-list/vendor-list.component';
import { VendorService } from './services/vendor.service';
import { AppCommonModule } from '../common/app-common.module';

@NgModule({
  declarations: [
    AddCustomerComponent,
    CustomerListComponent,
    CustomerDetailsComponent,
    AddVendorComponent,
    VendorDetailsComponent,
    VendorListComponent 
  ],
  imports: [
    CommonModule,
    SaleRoutingModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule 
  ],
  providers:[
    CustomerService,
    VendorService,
    DataService
  ]
})
export class SaleModule { }