import { Component, OnInit } from '@angular/core';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Production } from 'src/app/administration/model/production.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonService } from 'src/app/common/services/common.service';
import { ProductionService } from 'src/app/administration/services/production.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-production',
  templateUrl: './add-production.component.html',
  styleUrls: ['./add-production.component.css']
})
export class AddProductionComponent implements OnInit {
  appHost: AppHost = new AppHost();
  clsProduction: Production = new Production();
  addProductionForm: FormGroup;
  lstUpazilas: any = [];
  reset: any = [{}];
  productionId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private _formBuilder: FormBuilder, private productionService: ProductionService, private dataService: DataService, private router: Router,
    private activatedRoute: ActivatedRoute, private matSnakBar: MatSnackBar) {
    this.addProductionForm = this._formBuilder.group({
       id: '',
       batchCode: ['',Validators.required],
       batch: ['',Validators.required],
       name:['',Validators.required],
       startDate: ['',Validators.required],
       expiredDate: ['',Validators.required],
       note: ['',Validators.required],
       rawProductCostTotal: ['',Validators.required],
       otherCostTotal: ['',Validators.required],
    })
  }
  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.productionId = +param.get("id");
      console.log(this.productionId)
      if (this.productionId > 0) {
        this.productionService.getById(this.productionId).subscribe((res: any) => {
          this.clsProduction = res.obj;
          this.addProductionForm.patchValue(this.clsProduction);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.addProductionForm.markAllAsTouched();
    console.log(this.addProductionForm.value)
    if (this.addProductionForm.valid) {
      this.clsProduction = this.addProductionForm.value;
      console.log(this.clsProduction);
      if (this.productionId > 0) {
        this.productionService.put(this.clsProduction).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
      else {
        this.productionService.post(this.clsProduction).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
    }
    else {
    }
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
      this.router.navigateByUrl("/administration/productionList");
    }
  }
}
