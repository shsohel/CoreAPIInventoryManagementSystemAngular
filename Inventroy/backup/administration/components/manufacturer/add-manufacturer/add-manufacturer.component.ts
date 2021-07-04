import { Component, OnInit } from '@angular/core';
import { Manufacturer } from 'src/app/administration/model/manufacturer.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ManufacturerService } from 'src/app/administration/services/manufacturer.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-manufacturer',
  templateUrl: './add-manufacturer.component.html',
  styleUrls: ['./add-manufacturer.component.css']
})
export class AddManufacturerComponent implements OnInit {
  manufacturer: Manufacturer = new Manufacturer();
  addManufacturerForm: FormGroup;
  reset: any = [{}];
  manufacturerId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private _formBuilder: FormBuilder, private manufacturerService: ManufacturerService, private dataService: DataService, private matSnakBar: MatSnackBar,
    private router: Router, private activeRoute: ActivatedRoute) {
    this.addManufacturerForm = this._formBuilder.group({
      id: '',
      name: ['', Validators.required],
      description: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.manufacturerId = +param.get("id");
      console.log(this.manufacturerId)
      if (this.manufacturerId > 0) {
        this.manufacturerService.getById(this.manufacturerId).subscribe((suc: any) => {
          this.manufacturer = suc.obj;
        //  this.workWithResponse(suc);
          this.addManufacturerForm.patchValue(this.manufacturer);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.manufacturer = this.addManufacturerForm.value;
    if (this.manufacturerId > 0) {
      this.manufacturer.id = this.manufacturerId;
      this.manufacturerService.put(this.manufacturer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.manufacturerService.post(this.manufacturer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
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
      this.router.navigateByUrl("/administration/manufacturerList");
    }
  }
}