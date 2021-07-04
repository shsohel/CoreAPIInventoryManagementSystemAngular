import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { AddCategoryComponent } from './components/category/add-category/add-category.component';
import { CategoryDetailsComponent } from './components/category/category-details/category-details.component';
import { UnitListComponent } from './components/unit/unit-list/unit-list.component';
import { AddUnitComponent } from './components/unit/add-unit/add-unit.component';
import { UnitDetailsComponent } from './components/unit/unit-details/unit-details.component';
import { AddOrganizationComponent } from './components/organization/add-organization/add-organization.component';
import { OrganizationListComponent } from './components/organization/organization-list/organization-list.component';
import { OrganizationDetailsComponent } from './components/organization/organization-details/organization-details.component';
import { AddShopComponent } from './components/shop/add-shop/add-shop.component';
import { ShopListComponent } from './components/shop/shop-list/shop-list.component';
import { ShopDetailsComponent } from './components/shop/shop-details/shop-details.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { AddProductComponent } from './components/product/add-product/add-product.component';
import { ProductDetailsComponent } from './components/product/product-details/product-details.component';
import { AddManufacturerComponent } from './components/manufacturer/add-manufacturer/add-manufacturer.component';
import { ManufacturerListComponent } from './components/manufacturer/manufacturer-list/manufacturer-list.component';
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


const routes: Routes = [
  { path: "employeeList", component: EmployeeListComponent },
  { path: "addEmployee", component: AddEmployeeComponent },
  { path: "addEmployee/:id", component: AddEmployeeComponent },
  { path: "categoryList", component: CategoryListComponent },
  { path: "addCategory", component: AddCategoryComponent },
  { path: "addCategory/:id", component: AddCategoryComponent },
  { path: "categoryDetails/:id", component: CategoryDetailsComponent },
  { path: "unitList", component: UnitListComponent },
  { path: "addUnit", component: AddUnitComponent },
  { path: "addUnit/:id", component: AddUnitComponent },
  { path: "unitDetails/:id", component: UnitDetailsComponent },
  { path: "addOrganization", component: AddOrganizationComponent },
  { path: "addOrganization/:id", component: AddOrganizationComponent },
  { path: "organizationList", component: OrganizationListComponent },
  { path: "organizationDetails/:id", component: OrganizationDetailsComponent },
  { path: "organizationDetails", component: OrganizationDetailsComponent },
  { path: "addShop", component: AddShopComponent },
  { path: "addShop/:id", component: AddShopComponent },
  { path: "shopList", component: ShopListComponent },
  { path: "shopDetails/:id", component: ShopDetailsComponent },
  { path: "productList", component: ProductListComponent },
  { path: "addProduct", component: AddProductComponent },
  { path: "addProduct/:id", component: AddProductComponent },
  { path: "productDetails/:id", component: ProductDetailsComponent },
  { path: "addManufacturer", component: AddManufacturerComponent },
  { path: "addManufacturer/:id", component: AddManufacturerComponent },
  { path: "manufacturerList", component: ManufacturerListComponent },
  { path: "manufacturerDetails/:id", component: ManufacturerDetailsComponent },
  { path: "addProductItem", component: AddProductItemComponent },
  { path: "addProductItem/:id", component: AddProductItemComponent },
  { path: "productItemList", component: ProductItemListComponent },
  { path: "productItemDetails/:id", component: ProductItemDetailsComponent },
  { path: "spAttribute", component: AddSpecificationAttributeComponent },
  { path: "spAttribute/:id", component: AddSpecificationAttributeComponent },
  { path: "spAttributeList", component: SpecificationAttributeListComponent },
  { path: "spAttributeDetails/:id", component: SpecificationAttributeDetailsComponent },
  { path: "addProduction", component: AddProductionComponent },
  { path: "addProduction/:id", component: AddProductionComponent },
  { path: "productionList", component: ProductionListComponent },
  { path: "productionDetails/:id", component: ProductionDetailsComponent },
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AdministrationRoutingModule { }
