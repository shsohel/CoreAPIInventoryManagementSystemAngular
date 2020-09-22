import { Component, OnInit } from '@angular/core';
import { ExternalTransferDetails } from 'src/app/finance/models/external-transfer.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { ExternalTransferService } from 'src/app/finance/services/external-transfer.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-external-tansfer-list',
  templateUrl: './external-tansfer-list.component.html',
  styleUrls: ['./external-tansfer-list.component.css']
})
export class ExternalTansferListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstExternalTransfer: ExternalTransferDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private externalTransferService: ExternalTransferService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.externalTransferService.GetTableData().subscribe((res: any) => {
      this.lstExternalTransfer = res.obj;
      this.dataSource.data = this.lstExternalTransfer;
      console.log(this.lstExternalTransfer);
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
  displayedColumns = ["externalTransferNo", "externalPersonName", "capturedDateString", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "externalTransferNo") {
      this.lstExternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.externalTransferNo),
          Number(b.externalTransferNo), this.isAssending);
      });
    }
    else if (columnHeadName == "externalPersonName") {
      this.lstExternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.externalPersonName, b.externalPersonName, this.isAssending);
      });
    }
    else if (columnHeadName == "capturedDateString") {
      this.lstExternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.capturedDateString),
          Number(b.capturedDateString), this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstExternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstExternalTransfer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstExternalTransfer;
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
        this.externalTransferService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}
