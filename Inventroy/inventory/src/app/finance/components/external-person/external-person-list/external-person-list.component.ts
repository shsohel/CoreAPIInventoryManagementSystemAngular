import { Component, OnInit } from '@angular/core';
import { ExternalPersonDetails } from 'src/app/finance/models/external-person.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { ExternalPersonService } from 'src/app/finance/services/external-person.service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-external-person-list',
  templateUrl: './external-person-list.component.html',
  styleUrls: ['./external-person-list.component.css']
})
export class ExternalPersonListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstExternalPerson: ExternalPersonDetails[] = []
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private externalPersonService: ExternalPersonService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.externalPersonService.GetTableData().subscribe((res: any) => {
      this.lstExternalPerson = res.obj;
      this.dataSource.data = this.lstExternalPerson;
      console.log(this.lstExternalPerson);
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
  displayedColumns = ["externalPersonNo","name","fathersName","mobileNo","address","statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "externalPersonNo") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.externalPersonNo),
          Number(b.externalPersonNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "fathersName") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.fathersName),
          Number(b.fathersName), this.isAssending);
      });
    }
    else if (columnHeadName == "mobileNo") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.mobileNo, b.mobileNo, this.isAssending);
      });
    }
    else if (columnHeadName == "address") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address, b.address, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstExternalPerson.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstExternalPerson;
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
        this.externalPersonService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}