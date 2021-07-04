import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Organization } from 'src/app/administration/model/organization.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { OrganizationService } from 'src/app/administration/services/organization.service';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { AppMatDialogComponent } from 'src/app/common/components/app-mat-dialog/app-mat-dialog.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstOrganizations: Organization[] = [];
  isShow: boolean = false;
  organizationId: number;
  reset: any = [{}];
  response: ResponseMessage = new ResponseMessage();
  constructor(private organizationService: OrganizationService, private matSnackBar: MatSnackBar, private dataSortingHelperService: DataSortingHelperService,
    private matTableService: MatTableService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getOrganziationTableData();
  }
  getOrganziationTableData(): void {
    this.organizationService.GetTableData().subscribe((res: any) => {
      this.lstOrganizations = res.obj;
      this.dataSource.data = this.lstOrganizations;
      console.log(this.lstOrganizations);
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
  displayedColumns = ["organizationNo", "name","mobileNo","email","webAddress", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "organizationNo") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.organizationNo),
          Number(b.organizationNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "mobileNo") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.mobileNo, b.mobileNo, this.isAssending);
      });
    }
    else if (columnHeadName == "email") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.email, b.email, this.isAssending);
      });
    }
    else if (columnHeadName == "webAddress") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.webAddress, b.webAddress, this.isAssending);
      });
    }

    else if (columnHeadName == "statusName") {
      this.lstOrganizations.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstOrganizations;
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
        this.organizationService.delete(data).subscribe((res: any) => {
          this.response.message = res.message;
          this.response.statusCode = res.statusCode;
          this.getOrganziationTableData();
          this.reset.push({});
        })
      }
    });
  }
}
