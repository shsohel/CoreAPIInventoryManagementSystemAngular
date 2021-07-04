import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataSortingHelperService } from 'src/app/common/services/DataSortingHelper.Service';
import { MatTableService } from 'src/app/common/services/MatTable.Service';
import { EmployeeService } from 'src/app/administration/services/employee.service';
import { Employee } from 'src/app/administration/model/employee.model';
import { EmployeeStatusCode } from 'src/app/administration/enums/employee-status-code.enum';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  dataSource = new MatTableDataSource();
  lstEmployees: Employee[] = [];
  isShow: boolean = false;
  response: ResponseMessage = new ResponseMessage();
  constructor(private employeeService: EmployeeService, public dataService: DataService, public matSnackBar: MatSnackBar,
    private dataSortingHelperService: DataSortingHelperService,private matTableService: MatTableService,  ) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getEmployeeTableData();
  }
  getEmployeeTableData(): void {
    this.employeeService.GetTableData().subscribe((res: any) => {
      this.lstEmployees = res.obj;
      this.dataSource.data = this.lstEmployees;
      console.log(this.lstEmployees);
    }, e => {
      this.matSnackBar.open(e.error.message, 'Ok', {
        duration: 10000
      })
    })
  }
  getStatus(id: number): string {
    if (id != 0) {
      return EmployeeStatusCode[id];
    }
    return ""
  }
  displayedColumns = ["employeeNo", "name", "designation", "mobile", "email", "statusName", "Action"];
  isAssending = true;
  sortTableData(event, columnHead) {
    const columnHeadName = columnHead.displayedColumns[event];
    if (columnHeadName == "employeeNo") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.employeeNo),
          Number(b.employeeNo), this.isAssending);
      });
    }
    else if (columnHeadName == "name") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.name, b.name, this.isAssending);
      });
    }
    else if (columnHeadName == "designation") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(a.designation, b.designation, this.isAssending);
      });
    }
    else if (columnHeadName == "mobile") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortNumericType(Number(a.mobile),
          Number(b.mobile), this.isAssending);
      });
    }
    else if (columnHeadName == "email") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(a.email, b.email, this.isAssending);
      });
    }
    else if (columnHeadName == "statusName") {
      this.lstEmployees.sort((a, b) => {
        return this.dataSortingHelperService.sortStringType(
          this.getStatus(a.status), this.getStatus(b.status), this.isAssending);
      });
    }
    this.matTableService.showHideUpDowmIcon(event);
    this.isAssending = !this.isAssending;
    this.dataSource.data = this.lstEmployees;
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
    // let dialogRef = this.dialog.open(AppMatDialogComponent, {
    //   width: '350px',
    //   data: {
    //     message: 'Are you sure to delete?', action: "Yes", no: "No"
    //   }
    // });
    // dialogRef.afterClosed().subscribe(result => {
    //   if (result == undefined) {
    //   const data = JSON.stringify(this.deletedId);
    //   this.vendorService.delete(this.verdorId).subscribe((res: ResponseMessage) => {
    //     this.response.message = res.message;
    //     this.response.statusCode = res.statusCode;
    //     this.getEmployeeTableData();
    //     this.reset.push({});
    //   })
    // }
    //   });
  }
}
