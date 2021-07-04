import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BankTransferService } from 'src/app/finance/services/bank-transfer.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-bank-transfer-details',
  templateUrl: './bank-transfer-details.component.html',
  styleUrls: ['./bank-transfer-details.component.css']
})
export class BankTransferDetailsComponent implements OnInit {
  bankTransferId: number;
  rejectReason: any;
  bankTransferDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private bankTransferService: BankTransferService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.bankTransferId = +e.get('id');
      if(this.bankTransferId != null){
        this.bankTransferService.GetDetails(this.bankTransferId).subscribe((res: any) => {
          this.bankTransferDetails = res.obj;
          console.log(this.bankTransferDetails)
          this.rejectReason = this.bankTransferDetails.rejectReason;
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
