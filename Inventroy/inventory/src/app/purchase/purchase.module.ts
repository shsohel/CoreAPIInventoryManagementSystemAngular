import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { AppCommonModule } from '../common/app-common.module';
import { PurchaseRoutingModule } from './purchase-routing.module';
import { AddSupplierComponent } from './components/supplier/add-supplier/add-supplier.component';
import { SupplierListComponent } from './components/supplier/supplier-list/supplier-list.component';
import { SupplierDetailsComponent } from './components/supplier/supplier-details/supplier-details.component';
import { SupplierService } from './services/supplier.service';
import { AddPurchaseComponent } from './components/purchase/add-purchase/add-purchase.component';
import { PurchaseListComponent } from './components/purchase/purchase-list/purchase-list.component';
import { PurchaseDetailsComponent } from './components/purchase/purchase-details/purchase-details.component';
import { PurchaseService } from './services/purchase.service';
@NgModule({
  declarations: [
      AddSupplierComponent,
      SupplierListComponent,
      SupplierDetailsComponent,
      AddPurchaseComponent,
      PurchaseListComponent,
      PurchaseDetailsComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule,
    PurchaseRoutingModule    
  ],
  providers:[
    DataService,
    SupplierService,
    PurchaseService
  ]
})
export class PurchaseModule { }