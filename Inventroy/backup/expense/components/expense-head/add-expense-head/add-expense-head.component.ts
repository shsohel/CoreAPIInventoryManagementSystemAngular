import { Component, OnInit } from '@angular/core';
import { ExpenseHeadDetails } from 'src/app/expense/models/expense-Head.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { ExpenseHeadService } from 'src/app/expense/services/expense-head.service';

import { ActivatedRoute, Router } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-expense-head',
  templateUrl: './add-expense-head.component.html',
  styleUrls: ['./add-expense-head.component.css']
})
export class AddExpenseHeadComponent implements OnInit {
  expenseHead: ExpenseHeadDetails = new ExpenseHeadDetails();
  addExpenseHeadForm: FormGroup;
  expenseHeadId: number;
  lstExpenseType= ExpenseTypeEnum
  expenseType:any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private expenseHeadService: ExpenseHeadService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addExpenseHeadForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      description: ['', Validators.required],
      expenseTypeId: ['', Validators.required],
      parentId: ['']
    })
  }
  ngOnInit() {
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.expenseHeadId = +param.get("id");
      console.log(this.expenseHeadId)
      if (this.expenseHeadId > 0) {
        this.expenseHeadService.getById(this.expenseHeadId).subscribe((suc: any) => {
          this.expenseHead = suc.obj;
          this.addExpenseHeadForm.patchValue(this.expenseHead);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.expenseHead = this.addExpenseHeadForm.value;
    if (this.expenseHeadId > 0) {
      this.expenseHead.id = this.expenseHeadId;
      this.expenseHeadService.put(this.expenseHead).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.expenseHeadService.post(this.expenseHead).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/expenseHeadList");
    }
  }
}