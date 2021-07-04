import { Component, OnInit } from '@angular/core';
import { SalaryPaymentDetails } from 'src/app/expense/models/salary-payment.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ExpenseTypeEnum } from 'src/app/expense/enums/expense-type.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { SalaryPaymentService } from 'src/app/expense/services/salary-payment.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/common/services/data.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-salary-payment',
  templateUrl: './add-salary-payment.component.html',
  styleUrls: ['./add-salary-payment.component.css']
})
export class AddSalaryPaymentComponent implements OnInit {
  salaryPayment: SalaryPaymentDetails = new SalaryPaymentDetails();
  addSalaryPaymentForm: FormGroup;
  lstExpenseType = ExpenseTypeEnum;
  expenseType: any;
  salaryPaymentId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private salaryPaymentService: SalaryPaymentService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addSalaryPaymentForm = this._formBuilder.group({
      id: [''],
      expenseHeadId: ['', Validators.required],
      voucherId: ['', Validators.required],
      salaryPaymentDate: ['', Validators.required],
      note: ['', Validators.required],
      paidAmount: ['', Validators.required],
      employeeId: ['', Validators.required],
    })
  }
  ngOnInit() {
    this.expenseType = Object.keys(ExpenseTypeEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.salaryPaymentId = +param.get("id");
      console.log(this.salaryPaymentId)
      if (this.salaryPaymentId > 0) {
        this.salaryPaymentService.getById(this.salaryPaymentId).subscribe((suc: any) => {
          this.salaryPayment = suc.obj;
          this.addSalaryPaymentForm.patchValue(this.salaryPayment);
          console.log(this.salaryPayment)
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.salaryPayment = this.addSalaryPaymentForm.value;
    if (this.salaryPaymentId > 0) {
      this.salaryPayment.id = this.salaryPaymentId;
      this.salaryPaymentService.put(this.salaryPayment).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.salaryPaymentService.post(this.salaryPayment).subscribe((res: any) => {
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
      this.router.navigateByUrl("/expense/salaryPaymentList");
    }
  }
}