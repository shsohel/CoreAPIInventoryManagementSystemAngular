import { Component, OnInit } from '@angular/core';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BankAccountDetails } from 'src/app/finance/models/bank-account.model';
import { BankAccountService } from 'src/app/finance/services/bank-account.service';
import { BankAccountTypeEnum } from 'src/app/common/enums/common-bank-accountType.enum';
import { AccountTransectionTypeEnum } from 'src/app/common/enums/account-transection-type.enum';

@Component({
  selector: 'app-add-bank-account',
  templateUrl: './add-bank-account.component.html',
  styleUrls: ['./add-bank-account.component.css']
})
export class AddBankAccountComponent implements OnInit {
  bankAccount: BankAccountDetails = new BankAccountDetails();
  addBankAccountForm: FormGroup;
  lstBankAccountType = BankAccountTypeEnum;
  lstTransectionType = AccountTransectionTypeEnum;
  accountType: any;
  transectionType: any;
  bankAccountId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private bankAccountService: BankAccountService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addBankAccountForm = this._formBuilder.group({
      id: [''],
      bankName: ['', Validators.required],
      branchName: ['', Validators.required],
      accountName: ['', Validators.required],
      accountNo: ['', Validators.required],
      accountType: ['', Validators.required],
      transectionType: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.accountType = Object.keys(BankAccountTypeEnum).filter(Number);
    this.transectionType = Object.keys(AccountTransectionTypeEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.bankAccountId = +param.get("id");
      console.log(this.bankAccountId)
      if (this.bankAccountId > 0) {
        this.bankAccountService.getById(this.bankAccountId).subscribe((suc: any) => {
          this.bankAccount = suc.obj;
          this.addBankAccountForm.patchValue(this.bankAccount);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.bankAccount = this.addBankAccountForm.value;
    if (this.bankAccountId > 0) {
      this.bankAccount.id = this.bankAccountId;
      this.bankAccountService.put(this.bankAccount).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.bankAccountService.post(this.bankAccount).subscribe((res: any) => {
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
      this.router.navigateByUrl("/finance/bankAccountList");
    }
  }
}
