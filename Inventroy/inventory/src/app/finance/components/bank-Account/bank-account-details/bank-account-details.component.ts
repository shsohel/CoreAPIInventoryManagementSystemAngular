import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BankAccountService } from 'src/app/finance/services/bank-account.service';

@Component({
  selector: 'app-bank-account-details',
  templateUrl: './bank-account-details.component.html',
  styleUrls: ['./bank-account-details.component.css']
})
export class BankAccountDetailsComponent implements OnInit {
  bankAccountId: number;
  bankAccountDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private bankAccountService: BankAccountService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.bankAccountId = +e.get('id');
      if(this.bankAccountId != null){
        this.bankAccountService.GetDetails(this.bankAccountId).subscribe((res: any) => {
          this.bankAccountDetails = res.obj;
          console.log(this.bankAccountDetails)
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