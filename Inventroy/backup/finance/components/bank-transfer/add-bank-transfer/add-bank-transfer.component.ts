import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { BankTransferDetails } from 'src/app/finance/models/bank-transfer.model';
import { BankTransferService } from 'src/app/finance/services/bank-transfer.service';

@Component({
  selector: 'app-add-bank-transfer',
  templateUrl: './add-bank-transfer.component.html',
  styleUrls: ['./add-bank-transfer.component.css']
})
export class AddBankTransferComponent implements OnInit {
  bankTransfer: BankTransferDetails = new BankTransferDetails();
  addBankTransferForm: FormGroup;
  reset: any = [{}];
  bankTransferId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private bankTransferService: BankTransferService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addBankTransferForm = this._formBuilder.group({
      id: [''],
      bankAccountId: ['', Validators.required],
      amount: ['', Validators.required],
      note: ['', Validators.required],
      transferPurpose: ['', Validators.required],
      responsiblePersonId: [''],
      capturedDate: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.bankTransferId = +param.get("id");
      console.log(this.bankTransferId)
      if (this.bankTransferId > 0) {
        this.bankTransferService.getById(this.bankTransferId).subscribe((suc: any) => {
          this.bankTransfer = suc.obj;
          this.addBankTransferForm.patchValue(this.bankTransfer);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.bankTransfer = this.addBankTransferForm.value;
    if (this.bankTransferId > 0) {
      this.bankTransfer.id = this.bankTransferId;
      this.bankTransferService.put(this.bankTransfer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.bankTransferService.post(this.bankTransfer).subscribe((res: any) => {
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
      this.router.navigateByUrl("/finance/bankTransferList");
    }
  }
}
