import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ShopDetails } from 'src/app/administration/model/shop.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ShopService } from 'src/app/administration/services/shop.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-shop',
  templateUrl: './add-shop.component.html',
  styleUrls: ['./add-shop.component.css']
})
export class AddShopComponent implements OnInit {
  shop: ShopDetails = new ShopDetails();
  addShopForm: FormGroup;
  shopId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private shopService: ShopService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addShopForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      designation: ['', Validators.required],
      address1: ['', Validators.required],
      address2: [''],
      phone: ['', Validators.required],
      vatRegNo: ['', Validators.required],
      emailForSystemGeneratedMail: ['', Validators.required],
      passwordForSystemGeneratedMail: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.shopId = +param.get("id");
      console.log(this.shopId)
      if (this.shopId > 0) {
        this.shopService.getById(this.shopId).subscribe((suc: any) => {
          this.shop = suc.obj;
          this.addShopForm.patchValue(this.shop);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.shop = this.addShopForm.value;
    if (this.shopId > 0) {
      this.shop.id = this.shopId;
      this.shopService.put(this.shop).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.shopService.post(this.shop).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == CommonStatusEnum.Active) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/administration/shopList");
    }
  }
}