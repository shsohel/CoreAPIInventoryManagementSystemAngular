import { Component, OnInit } from '@angular/core';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { DataService } from 'src/app/common/services/data.service';
import { ProductionService } from 'src/app/administration/services/production.service';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Production } from 'src/app/administration/model/production.model';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-production-list',
  templateUrl: './production-list.component.html',
  styleUrls: ['./production-list.component.css']
})
export class ProductionListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstProduction: Production[] = [];
  isShow: boolean = false;
  categoryId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private productionService: ProductionService, private matSnackBar: MatSnackBar, private dataSortingHelperService: DataSortingHelperService,
    private dataService: DataService, private matTableService: MatTableService, private dialog: MatDialog) { }


  ngOnInit() {
    this.getProductTableData();
  }
  getProductTableData(): void {
    this.productionService.GetTableData().subscribe((res: any) => {
      this.lstProduction = res.obj;
      this.dataSource.data = this.lstProduction;
      console.log(this.lstProduction);
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
  displayedColumns = ["productionNo", "name","batchCode","startDate","expiredDate", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "productionNo") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.productionNo),Number(b.productionNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "batchCode") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.batchCode, b.batchCode, this.isAssending);
      });
    }
    else if (columnHeadName == "startDate") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.startDate, b.startDate, this.isAssending);
      });
    }
    else if (columnHeadName == "expiredDate") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortDateType(a.expiredDate, b.expiredDate, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstProduction.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstProduction;
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
        this.productionService.delete(this.deletedId).subscribe((res: any) => {
          this.workWithResponse(res);
          this.getProductTableData();
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
      this.matSnackBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
    }
  }
}
