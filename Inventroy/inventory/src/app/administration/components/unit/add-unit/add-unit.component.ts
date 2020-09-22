import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UnitService } from 'src/app/administration/services/unit.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Unit } from 'src/app/administration/model/unit.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-unit',
  templateUrl: './add-unit.component.html',
  styleUrls: ['./add-unit.component.css']
})
export class AddUnitComponent implements OnInit {
  unit: Unit = new Unit();
  lstUnit: any;
  addUnitForm: FormGroup;
  reset: any = [{}];
  unitId: number;
  yesOrNo = YesOrNo;
  keyOfYesNo: any = new Object();
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private _formBuilder: FormBuilder, private unitService: UnitService, private dataService: DataService, private matSnakBar: MatSnackBar,
    private router: Router, private activeRoute: ActivatedRoute) {
    this.keyOfYesNo = Object.keys(this.yesOrNo).filter(Boolean);
    this.addUnitForm = this._formBuilder.group({
      id: [''],
      // unitNo: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      isInteger: ['', Validators.required],
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.unitId = +param.get("id");
      console.log(this.unitId)
      if (this.unitId > 0) {
        this.unitService.getById(this.unitId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          //console.log(suc.vendor)
          this.unit = suc.obj;
          this.addUnitForm.patchValue(this.unit);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.unit = this.addUnitForm.value;
    if (this.unitId > 0) {
      this.unit.id = this.unitId;
      this.unitService.put(this.unit).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.unitService.post(this.unit).subscribe((res: any) => {
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
      this.router.navigateByUrl("/administration/unitList");
    }
  }
}
