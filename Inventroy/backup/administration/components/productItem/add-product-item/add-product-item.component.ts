import { Component, OnInit } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ProductItem } from 'src/app/administration/model/product-item.model';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonService } from 'src/app/common/services/common.service';
import { ProductItemService } from 'src/app/administration/services/product-item.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { ProductType } from 'src/app/administration/enums/product-type.enum';

import { ProductAttributeService } from 'src/app/administration/services/product-attribute.service';
import { CreateProductAttr, ProductAttribute } from 'src/app/administration/model/product-attribute.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-product-item',
  templateUrl: './add-product-item.component.html',
  styleUrls: ['./add-product-item.component.css']
})
export class AddProductItemComponent implements OnInit {
  appHost: AppHost = new AppHost();
  lstcommon: any;
  commonData: CommonDataList = new CommonDataList();
  productItem: ProductItem = new ProductItem();
  lstProductItem: any;
  createProductAttr: CreateProductAttr= new CreateProductAttr();
  productAtrr: ProductAttribute []=[];
  addProductItemForm: FormGroup;
  addProductAttrForm:FormGroup;
  reset: any = [{}];
  productItemId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  productType = ProductType;
  keyOfproductType: any = new Object();
  constructor(private commonDataService: CommonService, private _formBuilder: FormBuilder, private productItemService: ProductItemService,
    private dataService: DataService, private router: Router, private activatedRoute: ActivatedRoute, private matSnakBar: MatSnackBar,
    private productAttributeService: ProductAttributeService) {
    this.keyOfproductType = Object.keys(this.productType).filter(Number);
    this.addProductItemForm = this._formBuilder.group({
       id: '',
       productId: ['', Validators.required],
       categoryId: ['', Validators.required],
       manufacturerId: ['', Validators.required],
       unitId: ['', Validators.required],
       barCode: ['', Validators.required],
       sku:['', Validators.required],
       productType:['', Validators.required],
       vatId: ['', Validators.required],
       isSerialProduct: ['', Validators.required],
    });
    this.addProductAttrForm = this._formBuilder.group({
      productAttribute: this._formBuilder.array([
        this.addProductAttributeForm()
      ]),
    });
  }
  addProductAttributeForm(): FormGroup {
    return this._formBuilder.group({
       id: '',
       productItemId: '',
       specificationAttrId: ['',Validators.required],
       specificationAttrValueId: ['',Validators.required],
       sequenceNo: ['',Validators.required],
       priceAdjustment: ['',Validators.required],
       weightAdjustment: ['',Validators.required]
    })
  }
  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.productItemId = +param.get("id");
      console.log(this.productItemId)
      if (this.productItemId > 0) {
        this.productItemService.getById(this.productItemId).subscribe((res: any) => {
          this.productItem = res.obj;
          console.log(this.productItem);
          this.addProductItemForm.patchValue(this.productItem);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
    this.commonDataService.get().subscribe((res: any) => {
      this.lstcommon = <CommonDataList>res.obj;
      console.log(this.lstcommon);
    })
  }
  onAddMoreAttribute() {
    (<FormArray>this.addProductAttrForm.get('productAttribute')).push(this.addProductAttributeForm());
  }
  onRemoveAtrribute(index: number) {
    (<FormArray>this.addProductAttrForm.get('productAttribute')).removeAt(index);
  }
  lstValue;
  onChangeAttribute(id) {
    if (this.lstcommon.lstSpecificationAttrValues != null) {
      this.lstValue = this.lstcommon.lstSpecificationAttrValues.filter(e => e.specificationAttrId == id);
    }
  }
  getAttrValu(id: number) {
    if (id > 0) {
      return this.lstcommon.lstSpecificationAttrValues.filter(e => e.specificationAttrId == id);
    }
  }
  onSubmit() {
    this.addProductItemForm.markAllAsTouched();
    console.log(this.addProductItemForm.value)
    if (this.addProductItemForm.valid) {
      this.productItem = this.addProductItemForm.value;
      console.log(this.productItem);
      if (this.productItemId > 0) {
        this.productItemService.put(this.productItem).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
      else {
        this.productItemService.post(this.productItem).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
    }
    else {
    }
  }
  onProductItemSave() {
    this.addProductItemForm.markAsTouched();
    if (this.addProductItemForm.valid) {
      console.log(this.addProductItemForm.valid)
      this.addProductItemForm.controls['id'].setValue(this.productItem.id);
      if (this.productItem.id > 0) {
        this.productItemService.put(this.addProductItemForm.value).subscribe((res: any) => {
          this.productItem = <ProductItem>res.obj;
       //   this.assignCommonData();
          this.assignDataToProAttrForm(this.productItem.id);
        });
      }
      else {
        this.productItemService.post(this.addProductItemForm.value).subscribe((res: any) => {
          this.productItem = <ProductItem>res.obj;
        //  this.assignCommonData();
        });
      }
    }
  }
  assignDataToProAttrForm(id: number) {
    if (id > 0) {
      let proAttriFormArray = <FormArray>this.addProductAttrForm.get('productAttribute');
      this.createProductAttr.mappingViewModels = proAttriFormArray.value;
      this.productAttributeService.getById(id).subscribe((res: any) => {
        this.productAtrr = <ProductAttribute[]>res.obj;
        console.log(this.productAtrr);
        if (this.productAtrr.length > 0) {
          console.log(this.productAtrr);
          if (proAttriFormArray.length < this.productAtrr.length) {
            for (let i = 1; i < this.productAtrr.length; i++) {
              this.onAddMoreAttribute();
            }
          }
          proAttriFormArray.patchValue(this.productAtrr);
        }
      });
    }
  }
  onProductAttributeSave() {
    let proAttriFormArray = <FormArray>this.addProductAttrForm.get('productAttribute');
    if (proAttriFormArray.valid) {
      for (let i = 0; i < proAttriFormArray.length; i++) {
        proAttriFormArray.at(i).get('productItemId').setValue(this.productItem.id);
        console.log(this.productItem.id);
        this.createProductAttr.mappingViewModels = proAttriFormArray.value;
        console.log(this.createProductAttr);
      }
      if (proAttriFormArray.at(0).get('id').value > 0) {
        this.productAttributeService.put(this.createProductAttr).subscribe((res: any) => {
          console.log(res.obj);
          this.productAtrr = <ProductAttribute[]>res.obj;
         this.workWithResponse(res);
        });
      }
      else {
        this.productAttributeService.post(this.createProductAttr).subscribe((res: any) => {
          console.log(res.obj);
          this.productAtrr = <ProductAttribute[]>res.obj;
         this.workWithResponse(res);
        });
      }
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/administration/productItemList");
    }
  }
}
