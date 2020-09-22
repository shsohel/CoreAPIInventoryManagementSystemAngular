import { Component, OnInit } from '@angular/core';
import { VAT } from 'src/app/finance/models/vat.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { VATService } from 'src/app/finance/services/vat.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-vat-list',
  templateUrl: './vat-list.component.html',
  styleUrls: ['./vat-list.component.css']
})
export class VatListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstVat: VAT[] = [];
  isShow: boolean = false;
  unitId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private vatService: VATService, private matSnackBar: MatSnackBar, private dataSortingHelperService: DataSortingHelperService,
    private matTableService: MatTableService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getVatTableData();
  }
  getVatTableData(): void {
    this.vatService.GetTableData().subscribe((res: any) => {
      this.lstVat = res.obj;
      this.dataSource.data = this.lstVat;
      console.log(this.lstVat);
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
  displayedColumns = ["vatNo", "name","amount","fromDate","toDate", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "vatNo") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.vatNo),
          Number(b.vatNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "amount") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.amount, b.amount, this.isAssending);
      });
    }
    else if (columnHeadName == "fromDate") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.fromDate, b.fromDate, this.isAssending);
      });
    }
    else if (columnHeadName == "toDate") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.toDate, b.toDate, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstVat.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstVat;
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
    let dialogRef = this.dialog.open(AppMatDialogComponent, {
      width: '350px',
      data: {
        message: 'Are you sure to delete?', action: "Yes", no: "No"
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == undefined) {
        const data = JSON.stringify(this.deletedId);
        this.vatService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVatTableData();
          this.reset.push({});
        })
      }
    });
  }
}
