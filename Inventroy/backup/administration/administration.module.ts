import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministrationRoutingModule } from './administration-routing.module';
import { MaterialModule } from '../common/module/material.module';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataService } from '../common/services/data.service';
import { EmployeeService } from './services/employee.service';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { CategoryService } from './services/category.service';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { AddCategoryComponent } from './components/category/add-category/add-category.component';
import { CategoryDetailsComponent } from './components/category/category-details/category-details.component';
import { UnitListComponent } from './components/unit/unit-list/unit-list.component';
import { UnitService } from './services/unit.service';
import { AddUnitComponent } from './components/unit/add-unit/add-unit.component';
import { UnitDetailsComponent } from './components/unit/unit-details/unit-details.component';
import { AddOrganizationComponent } from './components/organization/add-organization/add-organization.component';
import { CommonService } from '../common/services/common.service';
import { OrganizationListComponent } from './components/organization/organization-list/organization-list.component';
import { OrganizationService } from './services/organization.service';
import { AuthInterceptor } from '../common/components/auth/auth.interceptor';
import { AppCommonModule } from '../common/app-common.module';
import { OrganizationDetailsComponent } from './components/organization/organization-details/organization-details.component';
import { AddShopComponent } from './components/shop/add-shop/add-shop.component';
import { ShopDetailsComponent } from './components/shop/shop-details/shop-details.component';
import { ShopListComponent } from './components/shop/shop-list/shop-list.component';
import { ShopService } from './services/shop.service';
import { AddProductComponent } from './components/product/add-product/add-product.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product/product-details/product-details.component';
import { ManufacturerListComponent } from './components/manufacturer/manufacturer-list/manufacturer-list.component';
import { AddManufacturerComponent } from './components/manufacturer/add-manufacturer/add-manufacturer.component';
import { ManufacturerDetailsComponent } from './components/manufacturer/manufacturer-details/manufacturer-details.component';
import { AddProductItemComponent } from './components/productItem/add-product-item/add-product-item.component';
import { ProductItemListComponent } from './components/productItem/product-item-list/product-item-list.component';
import { ProductItemDetailsComponent } from './components/productItem/product-item-details/product-item-details.component';
import { AddSpecificationAttributeComponent } from './components/attribute/add-specification-attribute/add-specification-attribute.component';
import { SpecificationAttributeListComponent } from './components/attribute/specification-attribute-list/specification-attribute-list.component';
import { SpecificationAttributeDetailsComponent } from './components/attribute/specification-attribute-details/specification-attribute-details.component';
import { AddProductionComponent } from './components/production/add-production/add-production.component';
import { ProductionListComponent } from './components/production/production-list/production-list.component';
import { ProductionDetailsComponent } from './components/production/production-details/production-details.component';
import { ProductService } from './services/product.service';
import { MatRadioModule } from '@angular/material/radio';

@NgModule({
  declarations: [
    EmployeeListComponent,
    AddEmployeeComponent,
    CategoryListComponent,
    AddCategoryComponent,
    CategoryDetailsComponent,
    UnitListComponent,
    AddUnitComponent,
    UnitDetailsComponent,
    AddOrganizationComponent,
    OrganizationListComponent,
    OrganizationDetailsComponent,
    AddShopComponent,
    ShopDetailsComponent,
    ShopListComponent,
    AddProductComponent,
    ProductListComponent,
    ProductDetailsComponent,
    ManufacturerListComponent,
    AddManufacturerComponent,
    ManufacturerDetailsComponent,
    AddProductItemComponent,
    ProductItemListComponent,
    ProductItemDetailsComponent,
    AddSpecificationAttributeComponent,
    SpecificationAttributeListComponent,
    SpecificationAttributeDetailsComponent,
    AddProductionComponent,
    ProductionListComponent,
    ProductionDetailsComponent
  ],
  imports: [
    CommonModule,
    AdministrationRoutingModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppCommonModule,
    MatRadioModule 

  ],
  providers:[
    DataService,
    EmployeeService,
    CategoryService,
    UnitService,
    CommonService,
    OrganizationService,
    ShopService,
    ProductService
  ]
})
export class AdministrationModule { }