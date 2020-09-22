import { Component, OnInit } from '@angular/core';
import { PurchaseDetails } from 'src/app/purchase/models/purchase.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { PurchaseService } from 'src/app/purchase/services/purchase.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.css']
})
export class PurchaseListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstPurchase: PurchaseDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private purchaseService: PurchaseService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.purchaseService.GetTableData().subscribe((res: any) => {
      this.lstPurchase = res.obj;
      this.dataSource.data = this.lstPurchase;
      console.log(this.lstPurchase);
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
  displayedColumns = ["purchaseNo", "dateString", "purchaseOrderId", "supplierName", "amount", "responsibleEmpName", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "purchaseNo") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.purchaseNo),
          Number(b.purchaseNo), this.isAssending);
      });
    }
    else if (columnHeadName == "dateString") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.dateString, b.dateString, this.isAssending);
      });
    }
    else if (columnHeadName == "purchaseOrderId") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.purchaseOrderId),
          Number(b.purchaseOrderId), this.isAssending);
      });
    }
    else if (columnHeadName == "supplierName") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.supplierName, b.supplierName, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "responsibleEmpName") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.responsibleEmpName, b.responsibleEmpName, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstPurchase.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstPurchase;
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
        this.purchaseService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}