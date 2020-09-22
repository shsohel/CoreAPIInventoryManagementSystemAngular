import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SalaryPaymentService } from 'src/app/expense/services/salary-payment.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-salary-payment-details',
  templateUrl: './salary-payment-details.component.html',
  styleUrls: ['./salary-payment-details.component.css']
})
export class SalaryPaymentDetailsComponent implements OnInit {
  salaryPaymentId: number;
  rejectReason: any;
  salaryPaymentDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private salaryPaymentService: SalaryPaymentService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.salaryPaymentId = +e.get('id');
      if (this.salaryPaymentId != null) {
        this.salaryPaymentService.GetDetails(this.salaryPaymentId).subscribe((res: any) => {
          this.salaryPaymentDetails = res.obj;
          console.log(this.salaryPaymentDetails);          
          this.rejectReason = this.salaryPaymentDetails.rejectReason;
        }, e => {
          this.matSnackBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  getStatus(id: number): string {
    if (id != 0) {
      return CommonStatusEnum[id];
    }
    return ""
  }
}