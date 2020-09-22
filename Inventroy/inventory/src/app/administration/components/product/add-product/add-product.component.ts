import { Component, OnInit } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { Product } from 'src/app/administration/model/product.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonService } from 'src/app/common/services/common.service';
import { ProductService } from 'src/app/administration/services/product.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  appHost: AppHost = new AppHost();
  lstcommon: any;
  commonData: CommonDataList = new CommonDataList();
  product: Product = new Product();
  lstProduct: any;
  addProductForm: FormGroup;
  lstUpazilas: any = [];
  reset: any = [{}];
  fileUploadMessage: boolean = true;
  productId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private commonDataService: CommonService, private _formBuilder: FormBuilder, private productService: ProductService,
    private dataService: DataService, private router: Router,
    private activatedRoute: ActivatedRoute, private matSnakBar: MatSnackBar) {
    this.addProductForm = this._formBuilder.group({
      id: '',
      name: ['', Validators.required],
      description: ['', Validators.required],
      categoryId: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.productId = +param.get("id");
      console.log(this.productId)
      if (this.productId > 0) {
        this.productService.getById(this.productId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          //console.log(suc.vendor)
          this.product = suc.obj;
          this.addProductForm.patchValue(this.product);
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
  onSubmit() {
    this.addProductForm.markAllAsTouched();
    console.log(this.addProductForm.value)
    if (this.addProductForm.valid) {
      this.product = this.addProductForm.value;
      console.log(this.product);
      if (this.productId > 0) {
        this.productService.put(this.product).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
      else {
        this.productService.post(this.product).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
    }
    else {
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
      this.router.navigateByUrl("/administration/productList");
    }
  }
}
