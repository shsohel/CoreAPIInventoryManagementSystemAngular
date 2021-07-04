import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ExpenseHeadService } from 'src/app/expense/services/expense-head.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-expense-head-details',
  templateUrl: './expense-head-details.component.html',
  styleUrls: ['./expense-head-details.component.css']
})
export class ExpenseHeadDetailsComponent implements OnInit {
  expenseHeadId: number;
  expenseHeadDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private expenseHeadService: ExpenseHeadService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.expenseHeadId = +e.get('id');
      if (this.expenseHeadId != null) {
        this.expenseHeadService.GetDetails(this.expenseHeadId).subscribe((res: any) => {
          this.expenseHeadDetails = res.obj;
          console.log(this.expenseHeadDetails)
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
