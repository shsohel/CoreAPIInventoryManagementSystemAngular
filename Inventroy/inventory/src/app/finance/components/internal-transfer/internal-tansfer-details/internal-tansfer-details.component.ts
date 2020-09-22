import { Component, OnInit } from '@angular/core';
import { InternalTransferService } from 'src/app/finance/services/internal-transfer.service';
import { ActivatedRoute } from '@angular/router';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-internal-tansfer-details',
  templateUrl: './internal-tansfer-details.component.html',
  styleUrls: ['./internal-tansfer-details.component.css']
})
export class InternalTansferDetailsComponent implements OnInit {
  internalTransferId: number;
  rejectReason: any;
  internalTransferDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private internalTransferService: InternalTransferService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.internalTransferId = +e.get('id');
      if (this.internalTransferId != null) {
        this.internalTransferService.GetDetails(this.internalTransferId).subscribe((res: any) => {
          this.internalTransferDetails = res.obj;
          this.rejectReason = this.internalTransferDetails.rejectReason;
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
