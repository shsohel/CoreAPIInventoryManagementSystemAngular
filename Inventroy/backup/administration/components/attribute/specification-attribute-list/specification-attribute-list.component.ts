import { Component, OnInit } from '@angular/core';
import { SpecificationAttribute } from 'src/app/administration/model/specification-attribute.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { SpecificationAttributeService } from 'src/app/administration/services/specification-attribute.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { SpecificationAttributeValueService } from 'src/app/administration/services/specification-attribute-value.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-specification-attribute-list',
  templateUrl: './specification-attribute-list.component.html',
  styleUrls: ['./specification-attribute-list.component.css']
})
export class SpecificationAttributeListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstSpAttribute: SpecificationAttribute[] = [];
  isShow: boolean = false;
  //categoryId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private attributeService: SpecificationAttributeService, private matSnackBar: MatSnackBar, private attributeValueService:SpecificationAttributeValueService,
    private dataSortingHelperService: DataSortingHelperService,private dataService: DataService, private matTableService: MatTableService, 
    private dialog: MatDialog) { }


  ngOnInit() {
    this.getAttributeTableData();
  }
  getAttributeTableData(): void {
    this.attributeService.GetTableData().subscribe((res: any) => {
      this.lstSpAttribute = res.obj;
      this.dataSource.data = this.lstSpAttribute;
      console.log(this.lstSpAttribute);
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

  displayedColumns = ["attributeNo","name","sequence", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "attributeNo") {
      this.lstSpAttribute.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.attributeNo),Number(b.attributeNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstSpAttribute.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "sequence") {
      this.lstSpAttribute.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.sequence, b.sequence, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstSpAttribute.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstSpAttribute;
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
        this.attributeService.delete(this.deletedId).subscribe((res: any) => {
          this.workWithResponse(res);
          this.getAttributeTableData();
          this.reset.push({});
        });
        this.attributeValueService.delete(this.deletedId).subscribe((res:any)=>{
          this.response.responseObj=res.obj;
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

