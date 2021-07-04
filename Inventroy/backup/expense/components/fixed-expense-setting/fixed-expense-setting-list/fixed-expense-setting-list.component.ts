import { Component, OnInit } from '@angular/core';

import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { FixedExpenseSettingDetails } from 'src/app/expense/models/fixed-expense-setting.model';
import { FixedExpenseSettingService } from 'src/app/expense/services/fixed-expense-setting.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-fixed-expense-setting-list',
  templateUrl: './fixed-expense-setting-list.component.html',
  styleUrls: ['./fixed-expense-setting-list.component.css']
})
export class FixedExpenseSettingListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstFixedExpenseSetting: FixedExpenseSettingDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private fixedExpenseSettingService: FixedExpenseSettingService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.fixedExpenseSettingService.GetTableData().subscribe((res: any) => {
      this.lstFixedExpenseSetting = res.obj;
      this.dataSource.data = this.lstFixedExpenseSetting;
      console.log(this.lstFixedExpenseSetting);
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
  displayedColumns = ["fixedExpenseSettingNo", "expenseHeadName", "validFromString", "validToString", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "fixedExpenseNo") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.fixedExpenseSettingNo),
          Number(b.fixedExpenseSettingNo), this.isAssending);
      });
    }
    else if (columnHeadName == "expenseHeadName") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.expenseHeadName, b.expenseHeadName, this.isAssending);
      });
    }
    else if (columnHeadName == "validFromString") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.validFromString),
          Number(b.validFromString), this.isAssending);
      });
    }
    else if (columnHeadName == "validToString") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.validToString, b.validToString, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstFixedExpenseSetting.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstFixedExpenseSetting;
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
        this.fixedExpenseSettingService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}