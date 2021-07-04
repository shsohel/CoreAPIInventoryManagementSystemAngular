import { Component, OnInit } from '@angular/core';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { BankAccountDetails } from 'src/app/finance/models/bank-account.model';
import { BankAccountService } from 'src/app/finance/services/bank-account.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-bank-account-list',
  templateUrl: './bank-account-list.component.html',
  styleUrls: ['./bank-account-list.component.css']
})
export class BankAccountListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstBankAccount: BankAccountDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private bankAccountService: BankAccountService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.bankAccountService.GetTableData().subscribe((res: any) => {
      this.lstBankAccount = res.obj;
      this.dataSource.data = this.lstBankAccount;
      console.log(this.lstBankAccount);
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
  displayedColumns = ["bankAccountNo", "bankName", "branchName", "accountName", "accountNo", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "bankAccountNo") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.bankAccountNo),
          Number(b.bankAccountNo), this.isAssending);
      });
    }
    else if (columnHeadName == "bankName") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.bankName, b.bankName, this.isAssending);
      });
    }
    else if (columnHeadName == "branchName") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.branchName),
          Number(b.branchName), this.isAssending);
      });
    }
    else if (columnHeadName == "accountName") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.accountName, b.accountName, this.isAssending);
      });
    }
    else if (columnHeadName == "accountNo") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.accountNo, b.accountNo, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstBankAccount.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstBankAccount;
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
        this.bankAccountService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}