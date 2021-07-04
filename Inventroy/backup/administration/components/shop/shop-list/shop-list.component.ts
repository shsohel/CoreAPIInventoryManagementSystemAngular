import { Component, OnInit } from '@angular/core';
import { ShopDetails } from 'src/app/administration/model/shop.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { ShopService } from 'src/app/administration/services/shop.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.css']
})
export class ShopListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstShop: ShopDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private shopService: ShopService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.shopService.GetTableData().subscribe((res: any) => {
      this.lstShop = res.obj;
      this.dataSource.data = this.lstShop;
      //console.log(this.lstShop);
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
  displayedColumns = ["shopNo", "name", "designation", "phone", "address1", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "shopNo") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.code),
          Number(b.code), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "designation") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.designation),
          Number(b.designation), this.isAssending);
      });
    }
    else if (columnHeadName == "address1") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address1, b.address1, this.isAssending);
      });
    }
    else if (columnHeadName == "phone") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.phone, b.phone, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstShop.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstShop;
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
        this.shopService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}
