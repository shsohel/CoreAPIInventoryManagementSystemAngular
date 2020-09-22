import { Component, OnInit } from '@angular/core';
import { FixedExpenseService } from 'src/app/expense/services/fixed-expense.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ServiceProviderEnum } from 'src/app/common/enums/service-provider.enum';

@Component({
  selector: 'app-fixed-expense-details',
  templateUrl: './fixed-expense-details.component.html',
  styleUrls: ['./fixed-expense-details.component.css']
})
export class FixedExpenseDetailsComponent implements OnInit {
  fixedExpenseId: number;
  fixedExpenseDetails: any;
  serviceProvider = ServiceProviderEnum;
  constructor(private activatedRoute: ActivatedRoute, private fixedExpenseService: FixedExpenseService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.fixedExpenseId = +e.get('id');
      if (this.fixedExpenseId != null) {
        this.fixedExpenseService.GetDetails(this.fixedExpenseId).subscribe((res: any) => {
          this.fixedExpenseDetails = res.obj;
          console.log(this.fixedExpenseDetails)
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