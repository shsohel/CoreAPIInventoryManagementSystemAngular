import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ExternalTransferService } from 'src/app/finance/services/external-transfer.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-external-tansfer-details',
  templateUrl: './external-tansfer-details.component.html',
  styleUrls: ['./external-tansfer-details.component.css']
})
export class ExternalTansferDetailsComponent implements OnInit {
  externalTransferId: number;
  rejectReason: any;
  externalTransferDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private externalTransferService: ExternalTransferService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.externalTransferId = +e.get('id');
      if (this.externalTransferId != null) {
        this.externalTransferService.GetDetails(this.externalTransferId).subscribe((res: any) => {
          this.externalTransferDetails = res.obj;
          console.log(this.externalTransferDetails)
          this.rejectReason = this.externalTransferDetails.rejectReason;
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