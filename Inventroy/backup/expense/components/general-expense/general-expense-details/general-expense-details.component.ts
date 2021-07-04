import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GeneralExpenseService } from 'src/app/expense/services/general-expense.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-general-expense-details',
  templateUrl: './general-expense-details.component.html',
  styleUrls: ['./general-expense-details.component.css']
})
export class GeneralExpenseDetailsComponent implements OnInit {
  generalExpenseId: number;
  generalExpenseDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private generalExpenseService: GeneralExpenseService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.generalExpenseId = +e.get('id');
      if (this.generalExpenseId != null) {
        this.generalExpenseService.GetDetails(this.generalExpenseId).subscribe((res: any) => {
          this.generalExpenseDetails = res.obj;
          console.log(this.generalExpenseDetails)
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