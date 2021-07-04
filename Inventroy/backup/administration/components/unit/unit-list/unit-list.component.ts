import { Component, OnInit } from '@angular/core';
import { UnitService } from 'src/app/administration/services/unit.service';
import { Unit } from 'src/app/administration/model/unit.model';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-unit-list',
  templateUrl: './unit-list.component.html',
  styleUrls: ['./unit-list.component.css']
})
export class UnitListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstUnit: Unit[] = [];
  isShow: boolean = false;
  unitId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private unitService: UnitService, private matSnackBar: MatSnackBar, private dataSortingHelperService: DataSortingHelperService,
    private matTableService: MatTableService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getUnitTableData();
  }
  getUnitTableData(): void {
    this.unitService.GetTableData().subscribe((res: any) => {
      this.lstUnit = res.obj;
      this.dataSource.data = this.lstUnit;
      console.log(this.lstUnit);
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
  displayedColumns = ["unitNo", "name", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "unitNo") {
      this.lstUnit.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.unitNo),
          Number(b.unitNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstUnit.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }

    else if (columnHeadName == "statusName") {
      this.lstUnit.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstUnit;
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
       // const data = JSON.stringify(this.deletedId);
        this.unitService.delete(this.deletedId).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getUnitTableData();
          this.reset.push({});
        })
      }
    });
  }
}