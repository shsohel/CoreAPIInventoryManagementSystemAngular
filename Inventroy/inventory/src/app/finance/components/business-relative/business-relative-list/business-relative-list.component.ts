import { Component, OnInit } from '@angular/core';
import { BusinessRelativeDetails } from 'src/app/finance/models/business-relative.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { BusinessRelativeService } from 'src/app/finance/services/business-relative.service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { RelationshipEnum } from 'src/app/common/enums/common-basic.enum';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-business-relative-list',
  templateUrl: './business-relative-list.component.html',
  styleUrls: ['./business-relative-list.component.css']
})
export class BusinessRelativeListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstBusinessRelative: BusinessRelativeDetails[] = []
  lstRelation = RelationshipEnum
  isShow: boolean = false;
  reset = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private dataService: DataService, private matTableService: MatTableService, private matSnackBar: MatSnackBar, private matdialog: MatDialog,
    private dataSortingHelperService: DataSortingHelperService, private businessRelativeService: BusinessRelativeService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getVendorTableData();
  }
  getVendorTableData(): void {
    this.businessRelativeService.GetTableData().subscribe((res: any) => {
      this.lstBusinessRelative = res.obj;
      this.dataSource.data = this.lstBusinessRelative;
      console.log(this.lstBusinessRelative);
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
  displayedColumns = ["businessRelativeNo", "name", "relation", "mobileNo", "address", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "businessRelativeNo") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.businessRelativeNo, b.businessRelativeNo, this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "relation") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.relationshipId, b.relationshipId, this.isAssending);
      });
    }
    else if (columnHeadName == "mobileNo") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.mobileNo, b.mobileNo, this.isAssending);
      });
    }
    else if (columnHeadName == "address") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.address, b.address, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstBusinessRelative.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstBusinessRelative;
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
        this.businessRelativeService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getVendorTableData();
          this.reset.push({});
        })
      }
    });
  }
}