import { Component, OnInit } from '@angular/core';
import { ExpenseTypeDetails } from 'src/app/expense/models/expense-type.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ExpenseTypeService } from 'src/app/expense/services/expense-type.service';

import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-expense-type',
  templateUrl: './add-expense-type.component.html',
  styleUrls: ['./add-expense-type.component.css']
})
export class AddExpenseTypeComponent implements OnInit {
  expenseType: ExpenseTypeDetails = new ExpenseTypeDetails();
  addExpenseTypeForm: FormGroup;
  expenseTypeId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private expenseTypeService: ExpenseTypeService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addExpenseTypeForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      description: ['', Validators.required],
      isFixed: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.expenseTypeId = +param.get("id");
      console.log(this.expenseTypeId)
      if (this.expenseTypeId > 0) {
        this.expenseTypeService.getById(this.expenseTypeId).subscribe((suc: any) => {
          this.expenseType = suc.obj;
          this.addExpenseTypeForm.patchValue(this.expenseType);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.expenseType = this.addExpenseTypeForm.value;
    if (this.expenseTypeId > 0) {
      this.expenseType.id = this.expenseTypeId;
      this.expenseTypeService.put(this.expenseType).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.expenseTypeService.post(this.expenseType).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/expenseTypeList");
    }
  }
}