import { Component, OnInit } from '@angular/core';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { BusinessRelativeDetails } from 'src/app/finance/models/business-relative.model';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BusinessRelativeService } from 'src/app/finance/services/business-relative.service';
import { RelationshipEnum } from 'src/app/common/enums/common-basic.enum';

@Component({
  selector: 'app-add-business-relative',
  templateUrl: './add-business-relative.component.html',
  styleUrls: ['./add-business-relative.component.css']
})
export class AddBusinessRelativeComponent implements OnInit {
  businessRelative: BusinessRelativeDetails = new BusinessRelativeDetails();
  addBusinessRelativeForm: FormGroup;
  lstRelation = RelationshipEnum;
  relation: any;
  businessRelativeId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private businessRelativeService: BusinessRelativeService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addBusinessRelativeForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', Validators.required],
      address: ['', Validators.required],
      relationshipId: ['', Validators.required],
      description: ['', Validators.required],

    })
  }
  ngOnInit() {
    this.relation = Object.keys(RelationshipEnum).filter(Number);
    this.activeRoute.paramMap.subscribe(param => {
      this.businessRelativeId = +param.get("id");
      if (this.businessRelativeId > 0) {
        this.businessRelativeService.getById(this.businessRelativeId).subscribe((suc: any) => {
          this.businessRelative = suc.obj;
          this.addBusinessRelativeForm.patchValue(this.businessRelative);
          console.log(this.businessRelative);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.businessRelative = this.addBusinessRelativeForm.value;
    if (this.businessRelativeId > 0) {
      this.businessRelative.id = this.businessRelativeId;
      this.businessRelativeService.put(this.businessRelative).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.businessRelativeService.post(this.businessRelative).subscribe((res: any) => {
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
      this.router.navigateByUrl("/finance/businessRelativeList");
    }
  }
}