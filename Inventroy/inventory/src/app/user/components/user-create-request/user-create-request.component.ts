import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { UserCreateData } from '../../models/user-create-data.model';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/administration/model/employee.model';
import { startWith, map } from 'rxjs/operators';
import { UserCreateRequest } from '../../models/user-create-request.model';
import { DataService } from 'src/app/common/services/data.service';

@Component({
  selector: 'app-user-create-request',
  templateUrl: './user-create-request.component.html',
  styleUrls: ['./user-create-request.component.css']
})
export class UserCreateRequestComponent implements OnInit {

  userCreateRequestForm: FormGroup;
  lstEmployee: any = [{}];
  userCreateData: UserCreateData = new UserCreateData();
  filteredOptions: Observable<Employee[]>;
  userCreateRequest: UserCreateRequest = new UserCreateRequest();

  constructor(private formBuilder: FormBuilder, private userService: UserService, private dataService: DataService) {
    this.userCreateRequestForm = this.formBuilder.group({
      employeeId: ['', Validators.required],
      userType: ['', Validators.required],
      shopId: ['', Validators.required]
    })
  }

  ngOnInit() { 
    this.userService.GetUserCreateData().subscribe((res: any) => {
      this.userCreateData = res.obj;
    });
    this.filterBaseOnShop();
  }
  onShopChange(event) {
    this.lstEmployee = [];
    let shopId = event.target.value;
    this.userCreateData.employees.filter(e => {
      if (e.shopId == shopId) {
        this.lstEmployee.push(e);
      }
    });
    this.filterBaseOnShop();
  }
  filterBaseOnShop() {
    this.filteredOptions = this.userCreateRequestForm.controls['employeeId'].valueChanges
      .pipe(
        startWith(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(name) : this.lstEmployee.slice())
      );
  }
  private _filter(name: string): Employee[] {
    const filterValue = name.toLowerCase();

    return this.lstEmployee.filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }
  displayFn(user?: Employee): string | undefined {
    return user ? user.name : undefined;
  }
  employeeId;
  onOptionSelected(event) {
    let employee = event.option.value;
    this.employeeId = event.option.value.id;
  }
  onSendRequest(){
    let url = document.location.protocol + '//' + document.location.hostname + ':3200/user/signup?';
    this.userCreateRequest = this.userCreateRequestForm.value;
    this.userCreateRequest.url = url;
    this.userCreateRequest.employeeId = this.employeeId;
    this.userService.post(this.userCreateRequest).subscribe((res: any) => {
      
    });

  }
}
