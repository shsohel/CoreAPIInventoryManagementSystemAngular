import { Component, OnInit } from '@angular/core';
import { PayIncentiveDetails } from 'src/app/incentive/models/pay-incentive.module';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { PayIncentiveService } from 'src/app/incentive/services/pay-incentive.service';
import { IncentiveTypeEnum } from 'src/app/incentive/enums/incentive-type.enum';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';
import { Employee } from 'src/app/administration/model/employee.model';
import { EmployeeService } from 'src/app/administration/services/employee.service';

@Component({
  selector: 'app-add-pay-incentive',
  templateUrl: './add-pay-incentive.component.html',
  styleUrls: ['./add-pay-incentive.component.css']
})
export class AddPayIncentiveComponent implements OnInit {
  payIncentive: PayIncentiveDetails = new PayIncentiveDetails();
  lstEmployee: Employee [] = [];
  addPayIncentiveForm: FormGroup;
  lstIncentiveTypeEnum = IncentiveTypeEnum;
  incentiveType: any;
  lstExpenseType = ExpenseTypeEnum;
  expenseType: any;
  payIncentiveId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private payIncentiveService: PayIncentiveService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute, private employeeService: EmployeeService) {
    this.addPayIncentiveForm = this._formBuilder.group({
      id: [''],
      incentiveType: ['', Validators.required],
      paidToId: ['', Validators.required],
      paymentType: ['', Validators.required],
      responsibleEmpId: ['', Validators.required],
      paymentDate: ['', Validators.required],
      amount: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.incentiveType = Object.keys(IncentiveTypeEnum).filter(Number);
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.employeeService.GetTableData().subscribe((suc: any) => {
      this.lstEmployee = suc.obj;
    })
    this.activeRoute.paramMap.subscribe(param => {
      this.payIncentiveId = +param.get("id");
      console.log(this.payIncentiveId)
      if (this.payIncentiveId > 0) {
        this.payIncentiveService.getById(this.payIncentiveId).subscribe((suc: any) => {
          this.payIncentive = suc.obj;
          this.addPayIncentiveForm.patchValue(this.payIncentive);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.payIncentive = this.addPayIncentiveForm.value;
    if (this.payIncentiveId > 0) {
      this.payIncentive.id = this.payIncentiveId;
      this.payIncentiveService.put(this.payIncentive).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.payIncentiveService.post(this.payIncentive).subscribe((res: any) => {
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
      this.router.navigateByUrl("/incentive/payIncentiveList");
    }
  }
}