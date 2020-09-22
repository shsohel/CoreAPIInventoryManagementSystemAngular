import { Component, OnInit } from '@angular/core';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from 'src/app/common/services/data.service';
import { FixedExpenseSettingDetails } from 'src/app/expense/models/fixed-expense-setting.model';
import { FixedExpenseSettingService } from 'src/app/expense/services/fixed-expense-setting.service';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';
import { ServiceProviderEnum } from 'src/app/common/enums/service-provider.enum';
import { PaybleTypeEnum } from 'src/app/common/enums/payble-type.enum';

@Component({
  selector: 'app-add-fixed-expense-setting',
  templateUrl: './add-fixed-expense-setting.component.html',
  styleUrls: ['./add-fixed-expense-setting.component.css']
})
export class AddFixedExpenseSettingComponent implements OnInit {
  fixedExpenseSetting: FixedExpenseSettingDetails = new FixedExpenseSettingDetails();
  addFixedExpenseSettingForm: FormGroup;
  lstExpenseType = ExpenseTypeEnum;
  lstServiceProvider = ServiceProviderEnum;
  lstPaybleType = PaybleTypeEnum;
  expenseType: any;
  serviceProverder: any;
  paybleType:any;
  fixedExpenseSettingId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private fixedExpenseSettingService: FixedExpenseSettingService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addFixedExpenseSettingForm = this._formBuilder.group({
      id: [''],
      expenseHeadId: ['', Validators.required],
      serviceProviderId: ['', Validators.required],
      payableType: ['', Validators.required],
      note: ['', Validators.required],
      amount: ['', Validators.required],
      validFrom: ['', Validators.required],      
      validTo: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.serviceProverder = Object.keys(ServiceProviderEnum).filter(Number);
    this.paybleType = Object.keys(PaybleTypeEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.fixedExpenseSettingId = +param.get("id");
      console.log(this.fixedExpenseSettingId)
      if (this.fixedExpenseSettingId > 0) {
        this.fixedExpenseSettingService.getById(this.fixedExpenseSettingId).subscribe((suc: any) => {
          this.fixedExpenseSetting = suc.obj;
          this.addFixedExpenseSettingForm.patchValue(this.fixedExpenseSetting);
          console.log(this.fixedExpenseSetting)
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.fixedExpenseSetting = this.addFixedExpenseSettingForm.value;
    if (this.fixedExpenseSettingId > 0) {
      this.fixedExpenseSetting.id = this.fixedExpenseSettingId;
      this.fixedExpenseSettingService.put(this.fixedExpenseSetting).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.fixedExpenseSettingService.post(this.fixedExpenseSetting).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/fixedExpenseSettingList");
    }
  }
}