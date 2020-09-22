import { Component, OnInit } from '@angular/core';
import { InternalTransfer } from 'src/app/finance/models/internal-transfer.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InternalTransferService } from 'src/app/finance/services/internal-transfer.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-internal-transfer',
  templateUrl: './add-internal-transfer.component.html',
  styleUrls: ['./add-internal-transfer.component.css']
})
export class AddInternalTransferComponent implements OnInit {
  vendor: InternalTransfer = new InternalTransfer();
  addInternalTransferForm: FormGroup;
  reset: any = [{}];
  internalTransfeId: number;
  response: ResponseMessage = new ResponseMessage();
  isAprroved: boolean = false;
  constructor(private _formBuilder: FormBuilder, private vendorService: InternalTransferService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addInternalTransferForm = this._formBuilder.group({
      id: [''],
      internalTransferNo: ['', Validators.required],
      sentBy: ['', Validators.required],
      sentTo: ['', Validators.required],
      amount: ['', Validators.required],
      note: ['', Validators.required],
      rejectReason: ['', Validators.required],
      isApproved: ['', Validators.required],
      sentDate: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.internalTransfeId = +param.get("id");
      console.log(this.internalTransfeId)
      if (this.internalTransfeId > 0) {
        this.vendorService.getById(this.internalTransfeId).subscribe((suc: any) => {
          this.vendor = suc.obj;
          this.addInternalTransferForm.patchValue(this.vendor);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.vendor = this.addInternalTransferForm.value;
    if (this.internalTransfeId > 0) {
      this.vendor.id = this.internalTransfeId;
      this.vendorService.put(this.vendor).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.vendorService.post(this.vendor).subscribe((res: any) => {
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
      this.router.navigateByUrl("/finance/internalTransferList");
    }
  }
}
