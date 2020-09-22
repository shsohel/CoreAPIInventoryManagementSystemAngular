import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Customer } from 'src/app/sale/models/Customer.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { CustomerService } from 'src/app/sale/services/customer.service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstCustomer: Customer[] = []
  isShow: boolean = false;
  lstCustomerUtils: any;
  reset = [{}];
  verdorId : number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private customerService: CustomerService, private dialog: MatDialog) { }

  ngOnInit() {
    // this.commonService.GetConmmonDataList("").subscribe((res: ResponseMessage) => {
    //   this.lstVendorUtils = res.responseObj;
    //   console.log(this.lstVendorUtils);
    // })
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getCustomerTableData();
  }
  getCustomerTableData(): void {
    this.customerService.GetTableData().subscribe((res: any) => {
      this.lstCustomer = res.obj;
      this.dataSource.data = this.lstCustomer;
      console.log(this.lstCustomer);
    }, e => {
      this.matSnackBar.open( e.error.message, 'Ok', {
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
  displayedColumns = ["customerNo", "name","mobile", "address","statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "customerNo") {
      this.lstCustomer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.customerNo),
          Number(b.customerNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstCustomer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "mobile") {
      this.lstCustomer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.mobile),
          Number(b.mobile), this.isAssending);
      });
    }
    else if (columnHeadName == "address") {
      this.lstCustomer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address, b.address, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstCustomer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstCustomer;
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
        this.customerService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getCustomerTableData();
          this.reset.push({});
        })
      }
    });
  }
}
