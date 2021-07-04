import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PurchaseService } from 'src/app/purchase/services/purchase.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-purchase-details',
  templateUrl: './purchase-details.component.html',
  styleUrls: ['./purchase-details.component.css']
})
export class PurchaseDetailsComponent implements OnInit {
  purchaseId: number;
  purchaseDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private purchaseService: PurchaseService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.purchaseId = +e.get('id');
      if (this.purchaseId != null) {
        this.purchaseService.GetDetails(this.purchaseId).subscribe((res: any) => {
          this.purchaseDetails = res.obj;
          console.log(this.purchaseDetails)
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