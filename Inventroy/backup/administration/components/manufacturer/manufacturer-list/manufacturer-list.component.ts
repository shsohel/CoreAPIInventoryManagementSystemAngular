import { Component, OnInit } from '@angular/core';
import { Manufacturer } from 'src/app/administration/model/manufacturer.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ManufacturerService } from 'src/app/administration/services/manufacturer.service';
import { DataService } from 'src/app/common/services/data.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html',
  styleUrls: ['./manufacturer-list.component.css']
})
export class ManufacturerListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstManufacturer: Manufacturer[] = [];
  isShow: boolean = false;
  categoryId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private manufacturerService: ManufacturerService, private matSnackBar: MatSnackBar, private dataService: DataService, private matSnakBar: MatSnackBar,
    private dataSortingHelperService: DataSortingHelperService, private matTableService: MatTableService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getCategoryTableData();
  }
  getCategoryTableData(): void {
    this.manufacturerService.GetTableData().subscribe((res: any) => {
      this.lstManufacturer = res.obj;
      this.dataSource.data = this.lstManufacturer;
      console.log(this.lstManufacturer);
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
  displayedColumns = ["manufacturerNo", "name", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "manufacturerNo") {
      this.lstManufacturer.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.manufacturerNo),
          Number(b.manufacturerNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstManufacturer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }

    else if (columnHeadName == "statusName") {
      this.lstManufacturer.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstManufacturer;
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
        this.manufacturerService.delete(this.deletedId).subscribe((res: any) => {
          this.workWithResponse(res);
          this.response.statusCode = res.statusCode;
          this.getCategoryTableData();
          this.reset.push({});
        })
      }
    });
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
    }
  }
}

