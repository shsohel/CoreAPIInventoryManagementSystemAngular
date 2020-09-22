import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PayIncentiveService } from 'src/app/incentive/services/pay-incentive.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-pay-incentive-details',
  templateUrl: './pay-incentive-details.component.html',
  styleUrls: ['./pay-incentive-details.component.css']
})
export class PayIncentiveDetailsComponent implements OnInit {
  payIncentiveId: number;
  payIncentiveDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private payIncentiveService: PayIncentiveService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.payIncentiveId = +e.get('id');
      if (this.payIncentiveId != null) {
        this.payIncentiveService.GetDetails(this.payIncentiveId).subscribe((res: any) => {
          this.payIncentiveDetails = res.obj;
          console.log(this.payIncentiveDetails)
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