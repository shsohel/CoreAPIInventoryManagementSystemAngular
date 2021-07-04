import { Component, OnInit } from '@angular/core';
import { ProductItem } from 'src/app/administration/model/product-item.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { DataService } from 'src/app/common/services/data.service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { ProductItemService } from 'src/app/administration/services/product-item.service';
import { ProductType } from 'src/app/administration/enums/product-type.enum';
import { ProductAttributeService } from 'src/app/administration/services/product-attribute.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-product-item-list',
  templateUrl: './product-item-list.component.html',
  styleUrls: ['./product-item-list.component.css']
})
export class ProductItemListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstProductItem: ProductItem[] = [];
  isShow: boolean = false;
  categoryId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private productItemService: ProductItemService, private matSnackBar: MatSnackBar, private dataSortingHelperService: DataSortingHelperService,
    private dataService: DataService, private matTableService: MatTableService, private dialog: MatDialog, private productAttributeServic:ProductAttributeService) { }


  ngOnInit() {
    this.getProductTableData();
  }
  getProductTableData(): void {
    this.productItemService.GetTableData().subscribe((res: any) => {
      this.lstProductItem = res.obj;
      this.dataSource.data = this.lstProductItem;
      console.log(this.lstProductItem);
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
  getProductType(id: number): string {
    if (id != 0) {
      return ProductType[id];
    }
    return ""
  }
  displayedColumns = ["productItemNo","manufacturerName","productName", "unitName","productType", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "productItemNo") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.productItemNo),Number(b.productItemNo), this.isAssending);
      });
    }
    else if (columnHeadName == "manufacturerName") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.manufacturerName, b.manufacturerName, this.isAssending);
      });
    }
    else if (columnHeadName == "productName") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.productName, b.productName, this.isAssending);
      });
    }
    else if (columnHeadName == "unitName") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.unitName, b.unitName, this.isAssending);
      });
    }
    else if (columnHeadName == "productType") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getProductType(a.productType), this.getProductType(b.productType), this.isAssending);
      });
    }

    else if (columnHeadName == "statusName") {
      this.lstProductItem.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstProductItem;
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
        this.productItemService.delete(this.deletedId).subscribe((res: any) => {
          this.workWithResponse(res);
          this.getProductTableData();
          this.reset.push({});
        });
        this.productAttributeServic.delete(this.deletedId).subscribe((res:any)=>{
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
