import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FixedExpenseSettingService } from 'src/app/expense/services/fixed-expense-setting.service';
import { ServiceProviderEnum } from 'src/app/common/enums/service-provider.enum';

@Component({
  selector: 'app-fixed-expense-setting-details',
  templateUrl: './fixed-expense-setting-details.component.html',
  styleUrls: ['./fixed-expense-setting-details.component.css']
})
export class FixedExpenseSettingDetailsComponent implements OnInit {
  fixedExpenseSettingId: number;
  fixedExpenseSettingDetails: any;
  serviceProvider = ServiceProviderEnum;
  constructor(private activatedRoute: ActivatedRoute, private fixedExpenseSettingService: FixedExpenseSettingService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.fixedExpenseSettingId = +e.get('id');
      if (this.fixedExpenseSettingId != null) {
        this.fixedExpenseSettingService.GetDetails(this.fixedExpenseSettingId).subscribe((res: any) => {
          this.fixedExpenseSettingDetails = res.obj;
          console.log(this.fixedExpenseSettingDetails)
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