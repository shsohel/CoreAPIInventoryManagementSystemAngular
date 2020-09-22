import { Component, OnInit } from '@angular/core';
import { Vendor, VendorDetails } from 'src/app/sale/models/vendor.model';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { VendorService } from 'src/app/sale/services/vendor.service';
import { VendorStatusCode } from 'src/app/sale/enums/vendor-satus-code.enum';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.css']
})
export class VendorListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstVendor: Vendor[] = []
  isShow: boolean = false;
  lstVendorUtils: any;
  reset = [{}];
  verdorId : number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private vendorService: VendorService, private dialog: MatDialog) { }

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
    this.vendorService.GetTableData().subscribe((res: any) => {
      this.lstVendor = res.obj;
      this.dataSource.data = this.lstVendor;
      console.log(this.lstVendor);
    }, e => {
      this.matSnackBar.open( e.error.message, 'Ok', {
        duration: 10000
      })
    })

  }
  getStatus(id: number): string {
    if (id != 0) {
      return VendorStatusCode[id];
    }
    return ""
  }
  displayedColumns = ["vendorNo", "vendorName", "registrationNo","mobileNo", "address","statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "vendorNo") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.vendorNo),
          Number(b.vendorNo), this.isAssending);
      });
    }
    else if (columnHeadName == "vendorName") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "registrationNo") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.registrationNo, b.registrationNo, this.isAssending);
      });
    }
    else if (columnHeadName == "mobileNo") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.mobileNo),
          Number(b.mobileNo), this.isAssending);
      });
    }
    else if (columnHeadName == "address") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address, b.address, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstVendor.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstVendor;
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
        this.vendorService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}
