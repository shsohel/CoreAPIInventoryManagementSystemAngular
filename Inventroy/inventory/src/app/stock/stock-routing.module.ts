import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { WarehouseListComponent } from './components/warehouse/warehouse-list/warehouse-list.component';
import { WarehouseDetailsComponent } from './components/warehouse/warehouse-details/warehouse-details.component';
import { AddWarehouseComponent } from './components/warehouse/add-warehouse/add-warehouse.component';

const routes: Routes = [
  { path: "addWarehouse", component:  AddWarehouseComponent},
  { path: "addWarehouse/:id", component:  AddWarehouseComponent},
  { path: "warehouseList", component:  WarehouseListComponent},
  { path: "warehouseDetails/:id", component:  WarehouseDetailsComponent},
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class StockRoutingModule { }
