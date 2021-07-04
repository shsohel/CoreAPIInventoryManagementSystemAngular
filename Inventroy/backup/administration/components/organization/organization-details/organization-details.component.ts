import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrganizationService } from 'src/app/administration/services/organization.service';
import { CommonService } from 'src/app/common/services/common.service';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Organization } from 'src/app/administration/model/organization.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-organization-details',
  templateUrl: './organization-details.component.html',
  styleUrls: ['./organization-details.component.css']
})
export class OrganizationDetailsComponent implements OnInit {
  lstcommon: any;
  appHost: AppHost = new AppHost();
  commonData: CommonDataList = new CommonDataList();
  organizationId: number;
  organization: any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private activatedRoute: ActivatedRoute, private organizationService: OrganizationService, private matSnackBar: MatSnackBar,
    private commonDataListService: CommonService, private dataService: DataService, ) { }

  ngOnInit() {
    if (this.dataService.responseMessageData != null) {
      this.response = this.dataService.responseMessageData;
      this.dataService.setValueToResponseMessageProperty(null);
    }
    this.getOrganizationDetails();
    this.commonDataListService.get().subscribe((res: any) => {
      this.commonData = <CommonDataList>res.obj;
      console.log(this.commonData);
    })
  }
  getOrganizationDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.organizationId = +e.get('id');
      if (this.organizationId != null) {
        this.organizationService.GetDetails(this.organizationId).subscribe((res: any) => {
          this.organization = res.obj;
          console.log(this.organization)
        }, e => {
          this.matSnackBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  getPostCode(id: number): string {
    if (id == null) {
      return '[not imported]';
    }
    let obj = this.commonData.lstPostOffices.filter(x => x.id == id);
    let name;
    obj.filter(e => { name = e.postCode });
    return name;
  }


  getPOName(id: number): string {
    if (id == null) {
      return '';
    }
    let obj = this.commonData.lstPostOffices.filter(x => x.postOfficeID == id);
    let name;
    obj.filter(e => { name = e.postOfficeName });
    return name;
  }

  getPostOffice(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonData.lstPostOffices != undefined) {
      let obj = this.commonData.lstPostOffices.filter(x => {
        if (x.id == id) {
          nam = x.postOfficeName
        }
      });
    }
    return nam;
  }
  getPSName(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonData.lstUpazilas != undefined) {
      let obj = this.commonData.lstUpazilas.filter(x => {
        if (x.id == id) {
          nam = x.upazilaName
        }
      });
    }
    return nam;
  }
  getDistrictName(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonData.lstDistricts != undefined) {
      let obj = this.commonData.lstDistricts.filter(x => {
        if (x.id == id) {
          nam = x.districtName
        }
      });
    }
    return nam;
  }
  getCountryName(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonData.lstCountries != undefined) {
      let obj = this.commonData.lstCountries.filter(x => {
        if (x.id == id) {
          nam = x.countryName
        }
      });
    }
    return nam;
  }
}
