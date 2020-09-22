import { Component, OnInit } from '@angular/core';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { FixedExpenseDetails } from 'src/app/expense/models/fixed-expense.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FixedExpenseService } from 'src/app/expense/services/fixed-expense.service';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';
import { ServiceProviderEnum } from 'src/app/common/enums/service-provider.enum';

@Component({
  selector: 'app-add-fixed-expense',
  templateUrl: './add-fixed-expense.component.html',
  styleUrls: ['./add-fixed-expense.component.css']
})
export class AddFixedExpenseComponent implements OnInit {
  fixedExpense: FixedExpenseDetails = new FixedExpenseDetails();
  addFixedExpenseForm: FormGroup;
  lstExpenseType = ExpenseTypeEnum;
  lstServiceProvider = ServiceProviderEnum;
  expenseType: any;
  serviceProverder: any;
  fixedExpenseId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private fixedExpenseService: FixedExpenseService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addFixedExpenseForm = this._formBuilder.group({
      id: [''],
      expenseHeadId: ['', Validators.required],
      voucherId: ['', Validators.required],
      fixedExpenseDate: ['', Validators.required],
      note: ['', Validators.required],
      amount: ['', Validators.required],
      serviceProviderId: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.serviceProverder = Object.keys(ServiceProviderEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.fixedExpenseId = +param.get("id");
      console.log(this.fixedExpenseId)
      if (this.fixedExpenseId > 0) {
        this.fixedExpenseService.getById(this.fixedExpenseId).subscribe((suc: any) => {
          this.fixedExpense = suc.obj;
          this.addFixedExpenseForm.patchValue(this.fixedExpense);
          console.log(this.fixedExpense)
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.fixedExpense = this.addFixedExpenseForm.value;
    if (this.fixedExpenseId > 0) {
      this.fixedExpense.id = this.fixedExpenseId;
      this.fixedExpenseService.put(this.fixedExpense).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.fixedExpenseService.post(this.fixedExpense).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/fixedExpenseList");
    }
  }
}