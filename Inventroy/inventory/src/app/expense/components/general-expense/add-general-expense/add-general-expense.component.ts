import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GeneralExpenseDetails } from 'src/app/expense/models/general-expense.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { GeneralExpenseService } from 'src/app/expense/services/general-expense.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';

@Component({
  selector: 'app-add-general-expense',
  templateUrl: './add-general-expense.component.html',
  styleUrls: ['./add-general-expense.component.css']
})
export class AddGeneralExpenseComponent implements OnInit {
  generalExpense: GeneralExpenseDetails = new GeneralExpenseDetails();
  addGeneralExpenseForm: FormGroup;
  lstExpenseType = ExpenseTypeEnum;
  expenseType: any;
  serviceProverder: any;
  generalExpenseId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private generalExpenseService: GeneralExpenseService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addGeneralExpenseForm = this._formBuilder.group({
      id: [''],
      expenseHeadId: ['', Validators.required],
      voucherId: ['', Validators.required],
      generalExpenseDate: ['', Validators.required],
      note: ['', Validators.required],
      amount: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.generalExpenseId = +param.get("id");
      console.log(this.generalExpenseId)
      if (this.generalExpenseId > 0) {
        this.generalExpenseService.getById(this.generalExpenseId).subscribe((suc: any) => {
          this.generalExpense = suc.obj;
          this.addGeneralExpenseForm.patchValue(this.generalExpense);
          console.log(this.generalExpense)
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.generalExpense = this.addGeneralExpenseForm.value;
    if (this.generalExpenseId > 0) {
      this.generalExpense.id = this.generalExpenseId;
      this.generalExpenseService.put(this.generalExpense).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.generalExpenseService.post(this.generalExpense).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/generalExpenseList");
    }
  }
}