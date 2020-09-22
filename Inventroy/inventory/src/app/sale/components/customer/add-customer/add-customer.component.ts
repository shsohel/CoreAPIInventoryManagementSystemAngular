import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Customer } from 'src/app/sale/models/Customer.model';
import { CustomerService } from 'src/app/sale/services/customer.service';
import { VendorStatusCode } from 'src/app/sale/enums/vendor-satus-code.enum';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  customer: Customer = new Customer();
  addCustomerForm: FormGroup;
  response: ResponseMessage = new ResponseMessage();
  reset: any = [{}];
  customerId: number;
  constructor(private _formBuilder: FormBuilder, private customerService: CustomerService,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute, private matSnakBar: MatSnackBar) {
    this.addCustomerForm = this._formBuilder.group({
      id: [''],
      organizationId: ['', Validators.required],
      shopId: ['', Validators.required],
      name: ['', Validators.required],
      mobile: ['', Validators.required],
      address: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.customerId = +param.get("id");
      if (this.customerId > 0) {
        this.customerService.getById(this.customerId).subscribe((suc: any) => {
          console.log(suc);
          this.customer = suc.obj;
          this.addCustomerForm.patchValue(this.customer);
        }, e=>{
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.customer = this.addCustomerForm.value;
    if (this.customerId > 0) {
      this.customer.id = this.customerId;
      this.customerService.put(this.customer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.customerService.post(this.customer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == VendorStatusCode.drafted) {
      this.dataService.setValueToResponseMessageProperty(this.response);  
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
    }
    this.router.navigateByUrl("/sale/customerList");
  }
}