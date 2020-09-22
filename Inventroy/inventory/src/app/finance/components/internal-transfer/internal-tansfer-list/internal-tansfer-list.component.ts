import { Component, OnInit } from '@angular/core';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { InternalTransferService } from 'src/app/finance/services/internal-transfer.service';
import { DataService } from 'src/app/common/services/data.service';
import { InternalTransferDetails } from 'src/app/finance/models/internal-transfer.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-internal-tansfer-list',
  templateUrl: './internal-tansfer-list.component.html',
  styleUrls: ['./internal-tansfer-list.component.css']
})
export class InternalTansferListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstInternalTransfer: InternalTransferDetails[] = []
  isShow: boolean = false;
  //lstInternalTransferUtils: any;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private internalTransferService: InternalTransferService) { }

  ngOnInit() {
    // this.commonService.GetConmmonDataList("").subscribe((res: ResponseMessage) => {
    //   this.lstVendorUtils = res.responseObj;
    //   console.log(this.lstVendorUtils);
    // })
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.internalTransferService.GetTableData().subscribe((res: any) => {
      this.lstInternalTransfer = res.obj;
      this.dataSource.data = this.lstInternalTransfer;
      console.log(this.lstInternalTransfer);
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
  displayedColumns = ["internalTransferNo", "sentBy", "sentTo", "sentDateString", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "internalTransferNo") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.internalTransferNo),
          Number(b.internalTransferNo), this.isAssending);
      });
    }
    else if (columnHeadName == "sentBy") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.sentByName, b.sentByName, this.isAssending);
      });
    }
    else if (columnHeadName == "sentTo") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.sentToName, b.sentToName, this.isAssending);
      });
    }
    else if (columnHeadName == "sentDateString") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.sentDateString),
          Number(b.sentDateString), this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstInternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstInternalTransfer;
  }
  showSearchBox(id: string) {
    this.isShow = !this.isShow;
    this.matTableService.showSearchBox(id, this.isShow);
  }
  closeSearchBox(show: boolean) {
    this.isShow = !this.isShow;
    this.matTableService.closeSearchBox(this.isShow);
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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
        this.internalTransferService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}