import { Component, OnInit } from '@angular/core';
import { PayIncentiveDetails } from 'src/app/incentive/models/pay-incentive.module';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { PayIncentiveService } from 'src/app/incentive/services/pay-incentive.service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-pay-incentive-list',
  templateUrl: './pay-incentive-list.component.html',
  styleUrls: ['./pay-incentive-list.component.css']
})
export class PayIncentiveListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstPayIncentive: PayIncentiveDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private payIncentiveService: PayIncentiveService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.payIncentiveService.GetTableData().subscribe((res: any) => {
      this.lstPayIncentive = res.obj;
      this.dataSource.data = this.lstPayIncentive;
      console.log(this.lstPayIncentive);
    }, e => {
      this.matSnackBar.open(e.error.message, 'Ok', {
        duration: 10000
      })
    })

  }
  getStatus(id: number): string {
    if (id != 0) {
      return CommonStatusEnum[id];
    }
    return ""
  }
  displayedColumns = ["payIncentiveNo", "incentiveTypeName", "paidToName","paymentDateString", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "payIncentiveNo") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.payIncentiveNo),
          Number(b.payIncentiveNo), this.isAssending);
      });
    }
    else if (columnHeadName == "incentiveTypeName") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.incentiveTypeName, b.incentiveTypeName, this.isAssending);
      });
    }
    else if (columnHeadName == "paidToName") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.paidToName),
          Number(b.paidToName), this.isAssending);
      });
    }
    else if (columnHeadName == "paymentDateString") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortDateType(a.paymentDateString, b.paymentDateString, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstPayIncentive.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstPayIncentive;
  }
  showSearchBox(id: string) {
    this.isShow = !this.isShow;
    this.matTableService.showSearchBox(id, this.isShow);
  }
  closeSearchBox(show: boolean) {
    this.isShow = !this.isShow;
    this.matTableService.closeSearchBox(this.isShow);
  }
  deletedId;
  onDelete(id: number) {
    this.deletedId = id;
    console.log(this.deletedId);
    this.onOptionSelected();
  }
  onOptionSelected() {
    let dialogRef = this.matdialog.open(AppMatDialogComponent, {
      width: '350px',
      data: {
        message: 'Are you sure to delete?', action: "Yes", no: "No"
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == undefined) {
        const data = JSON.stringify(this.deletedId);
        this.payIncentiveService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}