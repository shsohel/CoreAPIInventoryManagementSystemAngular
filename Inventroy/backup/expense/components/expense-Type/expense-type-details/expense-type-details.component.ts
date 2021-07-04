import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExpenseTypeService } from 'src/app/expense/services/expense-type.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-expense-type-details',
  templateUrl: './expense-type-details.component.html',
  styleUrls: ['./expense-type-details.component.css']
})
export class ExpenseTypeDetailsComponent implements OnInit {
  expenseTypeId: number;
  expenseTypeDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private expenseTypeService: ExpenseTypeService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.expenseTypeId = +e.get('id');
      if (this.expenseTypeId != null) {
        this.expenseTypeService.GetDetails(this.expenseTypeId).subscribe((res: any) => {
          this.expenseTypeDetails = res.obj;
          console.log(this.expenseTypeDetails)
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