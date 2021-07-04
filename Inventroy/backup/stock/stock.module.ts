import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../common/module/material.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { AppCommonModule } from '../common/app-common.module';
import { StockRoutingModule } from './stock-routing.module';
import { AddWarehouseComponent } from './components/warehouse/add-warehouse/add-warehouse.component';
import { WarehouseListComponent } from './components/warehouse/warehouse-list/warehouse-list.component';
import { WarehouseDetailsComponent } from './components/warehouse/warehouse-details/warehouse-details.component';
import { WarehouseService } from './services/warehouse.service';

@NgModule({
  declarations: [
  AddWarehouseComponent,
  WarehouseListComponent,
  WarehouseDetailsComponent],
  imports: [
    CommonModule,
    StockRoutingModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule 
  ],
  providers:[
    DataService,
    WarehouseService
  ]
})
export class StockModule { }