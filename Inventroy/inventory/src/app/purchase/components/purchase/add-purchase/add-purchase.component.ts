import { Component, OnInit } from '@angular/core';
import { PurchaseDetails } from 'src/app/purchase/models/purchase.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PurchaseService } from 'src/app/purchase/services/purchase.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-purchase',
  templateUrl: './add-purchase.component.html',
  styleUrls: ['./add-purchase.component.css']
})
export class AddPurchaseComponent implements OnInit {
  purchase: PurchaseDetails = new PurchaseDetails();
  addPurchaseForm: FormGroup;
  purchaseId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private purchaseService: PurchaseService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addPurchaseForm = this._formBuilder.group({
      id: [''],
      purchaseOrderId: ['', Validators.required],
      wareHouseId: ['', Validators.required],
      supplierId: ['', Validators.required],
      paidByEmpId: ['', Validators.required],
      responsibleEmpId: ['', Validators.required],
      note: ['', Validators.required],
      paidAmount: ['', Validators.required],
      amount: ['', Validators.required],
      transportCost: ['', Validators.required],
      labourCost: ['', Validators.required],
      vat: ['', Validators.required],
      othersCost: ['', Validators.required],
      isLocked: ['', Validators.required],
      isWarehoused: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.purchaseId = +param.get("id");
      console.log(this.purchaseId)
      if (this.purchaseId > 0) {
        this.purchaseService.getById(this.purchaseId).subscribe((suc: any) => {
          this.purchase = suc.obj;
          this.addPurchaseForm.patchValue(this.purchase);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.purchase = this.addPurchaseForm.value;
    if (this.purchaseId > 0) {
      this.purchase.id = this.purchaseId;
      this.purchaseService.put(this.purchase).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.purchaseService.post(this.purchase).subscribe((res: any) => {
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
      this.router.navigateByUrl("/purchase/purchaseList");
    }
  }
}