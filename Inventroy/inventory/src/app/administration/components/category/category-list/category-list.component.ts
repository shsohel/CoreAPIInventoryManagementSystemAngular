import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { CategoryDetails } from '../../../model/category.model';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstCategories: CategoryDetails[] = [];
  isShow: boolean = false;
  categoryId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private categoryService: CategoryService, private matSnackBar: MatSnackBar, private dataService: DataService, private matSnakBar: MatSnackBar,
    private dataSortingHelperService: DataSortingHelperService,
    private matTableService: MatTableService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getCategoryTableData();
  }
  getCategoryTableData(): void {
    this.categoryService.GetTableData().subscribe((res: any) => {
      this.lstCategories = res.obj;
      this.dataSource.data = this.lstCategories;
      console.log(this.lstCategories);
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
  displayedColumns = ["categoryNo", "name", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "categoryNo") {
      this.lstCategories.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.categoryNo),
          Number(b.categoryNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstCategories.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }

    else if (columnHeadName == "statusName") {
      this.lstCategories.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstCategories;
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
        this.categoryService.delete(this.deletedId).subscribe((res: any) => {
          this.workWithResponse(res);
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
