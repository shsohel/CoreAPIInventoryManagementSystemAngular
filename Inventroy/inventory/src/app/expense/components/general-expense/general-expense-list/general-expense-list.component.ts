import { Component, OnInit } from '@angular/core';

import { GeneralExpenseDetails } from 'src/app/expense/models/general-expense.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { GeneralExpenseService } from 'src/app/expense/services/general-expense.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-general-expense-list',
  templateUrl: './general-expense-list.component.html',
  styleUrls: ['./general-expense-list.component.css']
})
export class GeneralExpenseListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstGeneralExpense: GeneralExpenseDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private generalExpenseService: GeneralExpenseService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.generalExpenseService.GetTableData().subscribe((res: any) => {
      this.lstGeneralExpense = res.obj;
      this.dataSource.data = this.lstGeneralExpense;
      console.log(this.lstGeneralExpense);
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
  displayedColumns = ["generalExpenseNo", "expenseHeadName", "expenseDateString", "voucherId", "amount", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "generalExpenseNo") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.generalExpenseNo),
          Number(b.generalExpenseNo), this.isAssending);
      });
    }
    else if (columnHeadName == "expenseHeadName") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.expenseHeadName, b.expenseHeadName, this.isAssending);
      });
    }
    else if (columnHeadName == "expenseDateString") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.expenseDateString
        ),
          Number(b.expenseDateString), this.isAssending);
      });
    }
    else if (columnHeadName == "voucherId") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.voucherId, b.voucherId, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstGeneralExpense.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstGeneralExpense;
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
        this.generalExpenseService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}
