import { Component, OnInit } from '@angular/core';
import { WarehouseDetails } from 'src/app/stock/models/Warehouse.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { WarehouseService } from 'src/app/stock/services/warehouse.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './warehouse-list.component.html',
  styleUrls: ['./warehouse-list.component.css']
})
export class WarehouseListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstWarehouse: WarehouseDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private warehouseService: WarehouseService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.warehouseService.GetTableData().subscribe((res: any) => {
      this.lstWarehouse = res.obj;
      this.dataSource.data = this.lstWarehouse;
      console.log(this.lstWarehouse);
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
  displayedColumns = ["warehouseNo", "name", "mobileNo", "address", "contactPerson", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "warehouseNo") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.warehouseNo),
          Number(b.warehouseNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }    
    else if (columnHeadName == "mobileNo") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.mobileNo, b.mobileNo, this.isAssending);
      });
    }
    else if (columnHeadName == "address") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address, b.address, this.isAssending);
      });
    }
    else if (columnHeadName == "contactPerson") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.contactPerson, b.contactPerson, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstWarehouse.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstWarehouse;
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
        this.warehouseService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}