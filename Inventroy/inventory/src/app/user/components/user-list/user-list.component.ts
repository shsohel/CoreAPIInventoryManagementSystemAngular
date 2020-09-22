import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { UserService } from '../../services/user.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  dataSource = new MatTableDataSource();
  response: ResponseMessage = new ResponseMessage();
  lstUsers: any;

  constructor(private dataService: DataService, private userService: UserService, 
    private dataSortingHelperService: DataSortingHelperService, private matTableService: MatTableService) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getUserTableData();
  }
  getUserTableData(): void {
    this.userService.GetTableData().subscribe((res: any) => {
      this.lstUsers = res.obj;
      this.dataSource.data = this.lstUsers;
      console.log(this.lstUsers);
    })
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  getStatus(id: number): string {
    if (id != 0) {
      return CommonStatusEnum[id];
    }
    return ""
  }
  displayedColumns = ["sL", "name", "userType", "mobileNo", "email", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "name") {
      this.lstUsers.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.userName, b.userName, this.isAssending);
      });
    }
    else if (columnHeadName == "userType") {
      this.lstUsers.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.userTypeName, b.userTypeName, this.isAssending);
      });
    }
    else if (columnHeadName == "mobileNo") {
      this.lstUsers.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.mobileNo), Number(b.mobileNo), this.isAssending);
      });
    }
    else if (columnHeadName == "email") {
      this.lstUsers.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.email, b.email, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstUsers.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstUsers;
  }
  isShow = false;
  showSearchBox(id: string) {
    this.isShow = !this.isShow;
    this.matTableService.showSearchBox(id, this.isShow);
  }
  closeSearchBox(show: boolean) {
    this.isShow = !this.isShow;
    this.matTableService.closeSearchBox(this.isShow);
  }
  deletedId;
  onDelete(id: number) {
    this.deletedId = id;
    this.onOptionSelected();
  }
  onOptionSelected() {
    // let dialogRef = this.dialog.open(AppMatDialogComponent, {
    //   width: '350px',
    //   data: {
    //     message: 'Are you sure to delete?', action: "Yes", no: "No"
    //   }
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   if (result == undefined) {
    //     const data = JSON.stringify(this.deletedId);
    //     this.userService.deleteUser(data).subscribe((res: ResponseMessage) => {
    //       this.response.message = res.message;
    //       this.response.statusCode = res.statusCode;
    //       this.getUserTableData();
    //       this.reset.push({});
    //     })
    //   }
    // });
  }
}
