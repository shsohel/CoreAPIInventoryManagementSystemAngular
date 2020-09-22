import { Component, OnInit } from '@angular/core';
import { SupplierDetails } from 'src/app/purchase/models/supplier.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from 'src/app/common/services/data.service';
import { SupplierService } from 'src/app/purchase/services/supplier.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {
  supplier: SupplierDetails = new SupplierDetails();
  addSupplierForm: FormGroup;
  supplierId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private supplierService: SupplierService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addSupplierForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      email: ['', Validators.required],
      contactNumber: ['', Validators.required],
      contactPerson: ['', Validators.required],
      description: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.supplierId = +param.get("id");
      console.log(this.supplierId)
      if (this.supplierId > 0) {
        this.supplierService.getById(this.supplierId).subscribe((suc: any) => {
          this.supplier = suc.obj;
          this.addSupplierForm.patchValue(this.supplier);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.supplier = this.addSupplierForm.value;
    if (this.supplierId > 0) {
      this.supplier.id = this.supplierId;
      this.supplierService.put(this.supplier).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.supplierService.post(this.supplier).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == CommonStatusEnum.Active) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/purchase/supplierList");
    }
  }
}