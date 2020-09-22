import { Component, OnInit } from '@angular/core';
import { WarehouseDetails } from 'src/app/stock/models/Warehouse.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { WarehouseService } from 'src/app/stock/services/warehouse.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-warehouse',
  templateUrl: './add-warehouse.component.html',
  styleUrls: ['./add-warehouse.component.css']
})
export class AddWarehouseComponent implements OnInit {
  warehouse: WarehouseDetails = new WarehouseDetails();
  addWarehouseForm: FormGroup;
  warehouseId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private warehouseService: WarehouseService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addWarehouseForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      email: ['', Validators.required],
      mobileNo: ['', Validators.required],
      description: ['', Validators.required],
      isDefault: [''],
      address: ['', Validators.required],
      contactPerson: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.warehouseId = +param.get("id");
      console.log(this.warehouseId)
      if (this.warehouseId > 0) {
        this.warehouseService.getById(this.warehouseId).subscribe((suc: any) => {
          this.warehouse = suc.obj;
          this.addWarehouseForm.patchValue(this.warehouse);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.warehouse = this.addWarehouseForm.value;
    if (this.warehouseId > 0) {
      this.warehouse.id = this.warehouseId;
      this.warehouseService.put(this.warehouse).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.warehouseService.post(this.warehouse).subscribe((res: any) => {
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
      this.router.navigateByUrl("/stock/warehouseList");
    }
  }
}