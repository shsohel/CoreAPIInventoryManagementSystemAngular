import { Component, OnInit } from '@angular/core';
import { FixedExpenseDetails } from 'src/app/expense/models/fixed-expense.model';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { FixedExpenseService } from 'src/app/expense/services/fixed-expense.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-fixed-expense-list',
  templateUrl: './fixed-expense-list.component.html',
  styleUrls: ['./fixed-expense-list.component.css']
})
export class FixedExpenseListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstFixedExpense: FixedExpenseDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private fixedExpenseService: FixedExpenseService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.fixedExpenseService.GetTableData().subscribe((res: any) => {
      this.lstFixedExpense = res.obj;
      this.dataSource.data = this.lstFixedExpense;
      console.log(this.lstFixedExpense);
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
  displayedColumns = ["fixedExpenseNo", "expenseHeadName", "fixedExpenseDate", "voucherId", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "fixedExpenseNo") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.fixedExpenseNo),
          Number(b.fixedExpenseNo), this.isAssending);
      });
    }
    else if (columnHeadName == "expenseHeadName") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.expenseHeadName, b.expenseHeadName, this.isAssending);
      });
    }
    else if (columnHeadName == "fixedExpenseDate") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.fixedExpenseDate),
          Number(b.fixedExpenseDate), this.isAssending);
      });
    }
    else if (columnHeadName == "voucherId") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.voucherId, b.voucherId, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstFixedExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstFixedExpense;
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
        this.fixedExpenseService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}