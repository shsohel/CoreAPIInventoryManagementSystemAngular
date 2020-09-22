import { Component, OnInit } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { SpecificationAttribute, CreateAttrValue, SpecificationAttributeValue } from 'src/app/administration/model/specification-attribute.model';
import { FormGroup, Validators, FormBuilder, FormArray } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { CommonService } from 'src/app/common/services/common.service';
import { SpecificationAttributeService } from 'src/app/administration/services/specification-attribute.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';

import { SpecificationAttributeValueService } from 'src/app/administration/services/specification-attribute-value.service';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-specification-attribute',
  templateUrl: './add-specification-attribute.component.html',
  styleUrls: ['./add-specification-attribute.component.css']
})
export class AddSpecificationAttributeComponent implements OnInit {
  appHost: AppHost = new AppHost();
  lstcommon: any;
  commonData: CommonDataList = new CommonDataList();
  spAttribute: SpecificationAttribute = new SpecificationAttribute();
  lstProductItem: any;
  createSpAttrValue: CreateAttrValue= new CreateAttrValue();
  attributeValue: SpecificationAttributeValue []=[];
  addAttributeForm: FormGroup;
  addAttributeValueForm:FormGroup;
  reset: any = [{}];
  attributeId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  // productType = ProductType;
  // keyOfproductType: any = new Object();
  constructor(private commonDataService: CommonService, private _formBuilder: FormBuilder, private attributeService: SpecificationAttributeService,
    private dataService: DataService, private router: Router, private activatedRoute: ActivatedRoute, private matSnakBar: MatSnackBar,
    private attributeValueService: SpecificationAttributeValueService) {
    this.addAttributeForm = this._formBuilder.group({
       id: '',
       name: ['', Validators.required],
       sequence:['', Validators.required]
    });
    this.addAttributeValueForm = this._formBuilder.group({
      attributeValue: this._formBuilder.array([
        this.addProductAttributeForm()
      ]),
    });
  }
  addProductAttributeForm(): FormGroup {
    return this._formBuilder.group({
       id: '',
       specificationAttrId: '',
       attrValue: ['', Validators.required],
    })
  }
  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.attributeId = +param.get("id");
      console.log(this.attributeId)
      if (this.attributeId > 0) {
        this.attributeService.getById(this.attributeId).subscribe((res: any) => {
          this.spAttribute = res.obj;
          console.log(this.spAttribute);
          this.addAttributeForm.patchValue(this.spAttribute);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onAddMoreAttributeValue() {
    (<FormArray>this.addAttributeValueForm.get('attributeValue')).push(this.addProductAttributeForm());
  }
  onRemoveAtrributeValue(index: number) {
    (<FormArray>this.addAttributeValueForm.get('attributeValue')).removeAt(index);
  }
  onAttributeSave() {
    this.addAttributeForm.markAsTouched();
    if (this.addAttributeForm.valid) {
      console.log(this.addAttributeForm.valid)
      this.addAttributeForm.controls['id'].setValue(this.spAttribute.id);
      console.log("Hel");
      if (this.spAttribute.id > 0) {
        this.attributeService.put(this.addAttributeForm.value).subscribe((res: any) => {
          this.spAttribute = <SpecificationAttribute>res.obj;
       //   this.assignCommonData();
          this.assignDataToAttrValueForm(this.spAttribute.id);
        });
      }
      else {
        this.attributeService.post(this.addAttributeForm.value).subscribe((res: any) => {
          this.spAttribute = <SpecificationAttribute>res.obj;
        //  this.assignCommonData();
        });
      }
    }
  }
  assignDataToAttrValueForm(id: number) {
    if (id > 0) {
      let proAttriFormArray = <FormArray>this.addAttributeValueForm.get('attributeValue');
      this.createSpAttrValue.specificationAttrValueViewModels = proAttriFormArray.value;
      this.attributeValueService.getById(id).subscribe((res: any) => {
        this.attributeValue = <SpecificationAttributeValue[]>res.obj;
        console.log(this.attributeValue);
        if (this.attributeValue.length > 0) {
          console.log(this.attributeValue);
          if (proAttriFormArray.length < this.attributeValue.length) {
            for (let i = 1; i < this.attributeValue.length; i++) {
              this.onAddMoreAttributeValue();
            }
          }
          proAttriFormArray.patchValue(this.attributeValue);
        }
      });
    }
  }
  onAttributeValueSave() {
    console.group("He");
    let proAttriFormArray = <FormArray>this.addAttributeValueForm.get('attributeValue');
    console.log(proAttriFormArray.valid)
    if (proAttriFormArray.valid) {
      for (let i = 0; i < proAttriFormArray.length; i++) {
        proAttriFormArray.at(i).get('specificationAttrId').setValue(this.spAttribute.id);
        console.log(this.spAttribute.id);
        this.createSpAttrValue.specificationAttrValueViewModels = proAttriFormArray.value;
        console.log(this.createSpAttrValue);
      }
      if (proAttriFormArray.at(0).get('id').value > 0) {
        this.attributeValueService.put(this.createSpAttrValue).subscribe((res: any) => {
          console.log(res.obj);
          this.attributeValue = <SpecificationAttributeValue[]>res.obj;
         this.workWithResponse(res);
        });
      }
      else {
        this.attributeValueService.post(this.createSpAttrValue).subscribe((res: any) => {
          console.log(res.obj);
          this.attributeValue = <SpecificationAttributeValue[]>res.obj;
         this.workWithResponse(res);
        });
      }
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
      this.router.navigateByUrl("/administration/spAttributeList");
    }
  }
}
