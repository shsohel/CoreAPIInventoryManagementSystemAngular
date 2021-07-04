import { Component, OnInit } from '@angular/core';
import { CommonService } from 'src/app/common/services/common.service';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { Organization, OrgImageDocumentDetails } from 'src/app/administration/model/organization.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { OrganizationService } from 'src/app/administration/services/organization.service';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { OrganizationTypeEnum } from 'src/app/administration/enums/organization-type.enum';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { AppHost } from 'src/app/common/models/app-host.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-organization',
  templateUrl: './add-organization.component.html',
  styleUrls: ['./add-organization.component.css']
})
export class AddOrganizationComponent implements OnInit {
  url='http://localhost:53336/images/OrganizationImages'
  appHost: AppHost = new AppHost();
  lstcommon: any;
  commonData: CommonDataList = new CommonDataList();
  oragnization: Organization = new Organization();
  document: OrgImageDocumentDetails = new OrgImageDocumentDetails();
  lstOrganization: any;
  addOrganizationForm: FormGroup;
  lstUpazilas: any=[];
  reset: any = [{}];
  fileUploadMessage: boolean = true;
  organizationId: number;
  //document: ImageDetails = new ImageDetails();
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  lstOrganizationEnum = OrganizationTypeEnum;
  keyOfOrganizatioType: any = new Object();
  constructor(private commonDataList: CommonService, private _formBuilder: FormBuilder, private organizationService: OrganizationService,
    private dataService: DataService, private router: Router, private commonservice: CommonService,
    private activatedRoute: ActivatedRoute, private matSnakBar: MatSnackBar) {
    this.keyOfOrganizatioType = Object.keys(this.lstOrganizationEnum).filter(Number);
    this.addOrganizationForm = this._formBuilder.group({
      id: [''],
      organizationTypeId: ['', Validators.required],
      name: ['', Validators.required],
      founderName: ['', Validators.required],
      establishedOn: ['', Validators.required],
      telephoneNo: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', Validators.required],
      webAddress: ['', Validators.required],
      registrationNo: ['', Validators.required],
      registeredDate: ['', Validators.required],
      addressVillageHouse: ['', Validators.required],
      addressRoadBlockSector: ['', Validators.required],
      addressPostOffice: ['', Validators.required],
      addressPostCode: ['', Validators.required],
      addressUpazila: ['', Validators.required],
      addressDistrict: ['', Validators.required],
      addressCountry: ['', Validators.required],
      logoImage: ['', Validators.required],
      nameCardImage: ['', Validators.required]
    })
  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(param => {
      this.organizationId = +param.get("id");
      console.log(this.organizationId)
      if (this.organizationId > 0) {
        this.organizationService.getById(this.organizationId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          //console.log(suc.vendor)
          this.oragnization = suc.obj;
          this.addOrganizationForm.patchValue(this.oragnization);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
    this.commonDataList.get().subscribe((res: any) => {
      this.lstcommon = <CommonDataList>res.obj;
      console.log(this.lstcommon);
    })
  }
  onDistrictChange() {
    console.log(this.addOrganizationForm.get('addressDistrict').value);
    this.lstUpazilas = this.lstcommon.lstUpazilas.filter(e =>
      e.districtId == this.addOrganizationForm.get('addressDistrict').value
    )
    console.log(this.lstUpazilas);
  }
  onPostOfficeChange(event) {
    this.lstcommon.lstPostOffices.filter(e => {
      if (e.id == event.target.value) {
        this.addOrganizationForm.controls['addressPostCode'].setValue(e.postCode);
      }
    })
    console.log(event.target.value)
  }
  
  onCardClick(id: string) {
    console.log(document.getElementById(id));
    (<HTMLElement>document.getElementById(id)).click();
    if (this.isDisable) {
      alert("You already upload picture for this product. Please create this product first and edit later to change product picture")
    }
  }
  onLogoImageChange(event, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.document.logoImage = e.target.result;
          this.document.logoImageName = event.target.files[0].name;
          this.addOrganizationForm.controls["logoImage"].setValue(event.target.files[0].name);
        }
        reader.readAsDataURL(file);
      }
    }
  }
  onNameCardImageFileChange(event, messageId: string, imgId: string) {
    if (event.target.files.length > 0) {
      (<HTMLElement>document.getElementById(messageId)).style.display = 'none';
      (<HTMLElement>document.getElementById(imgId)).style.display = 'inline';
      for (let file of event.target.files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.document.nameCardImage = e.target.result;
          this.document.nameCardImageName = event.target.files[0].name;
          this.addOrganizationForm.controls["nameCardImage"].setValue(event.target.files[0].name);
        }
        reader.readAsDataURL(file);
      }
      this.fileUploadMessage = false;
    }
  }
  onRemove(field: string) {
    if (field == 'logoImage') {
      this.oragnization.logoImage = undefined;
      this.addOrganizationForm.controls["logoImage"].setValue('');
    }
    else if (field == 'nameCardImage') {
      this.oragnization.nameCardImage = undefined;
      this.addOrganizationForm.controls["nameCardImage"].setValue('');
    }
  }
  onSubmit() {
    this.addOrganizationForm.markAllAsTouched();
    console.log(this.addOrganizationForm.value)
    if (this.addOrganizationForm.valid) {
      this.oragnization = this.addOrganizationForm.value;
      this.oragnization.logoImageName = this.document.logoImageName;
      this.oragnization.logoImage = this.document.logoImage;
      this.oragnization.nameCardImage = this.document.nameCardImage;
      this.oragnization.nameCardImageName = this.document.nameCardImageName;
      console.log(this.oragnization);
     // let data = JSON.stringify(this.oragnization);
      if (this.organizationId > 0) {
        this.organizationService.put(this.oragnization).subscribe((res: any) => {
          this.workWithResponse(res);
        })
      }
      else {
        this.organizationService.post(this.oragnization).subscribe((res: any) => {
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
      this.router.navigateByUrl("/administration/organizationList");
    }
  }
}
