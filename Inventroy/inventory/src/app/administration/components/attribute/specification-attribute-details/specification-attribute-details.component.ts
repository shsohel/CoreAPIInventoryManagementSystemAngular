import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SpecificationAttributeService } from 'src/app/administration/services/specification-attribute.service';
import { AttributeDetails } from 'src/app/administration/model/specification-attribute.model';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { CommonService } from 'src/app/common/services/common.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-specification-attribute-details',
  templateUrl: './specification-attribute-details.component.html',
  styleUrls: ['./specification-attribute-details.component.css']
})
export class SpecificationAttributeDetailsComponent implements OnInit {
  attributeId: number;
  lstAttributeCls: AttributeDetails = new AttributeDetails();
  lstCommon: CommonDataList = new CommonDataList();
  response: ResponseMessage = new ResponseMessage();
  constructor(private activateRoute: ActivatedRoute, private attributeService: SpecificationAttributeService, private commonDataService: CommonService,
    private dataService: DataService, private matSnackBar: MatSnackBar) { }
  ngOnInit() {
    this.activateRoute.paramMap.subscribe(param => {
      this.attributeId = +param.get("id");
      if (this.attributeId > 0) {
        this.attributeService.GetDetails(this.attributeId).subscribe((res: any) => {
          // let obj = <StudentDetails>res.obj;
          this.lstAttributeCls = res.obj;
          console.log(this.lstAttributeCls);
          this.workWithResponse(res);
        })
      }
    });
    this.commonDataService.get().subscribe((res: any) => {
      this.lstCommon = <CommonDataList>res.obj;
      console.log(this.lstCommon);
    })
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnackBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
    }
  }
  getStatus(id: number): string {
    if (id != 0) {
      return CommonStatusEnum[id];
    }
    return ""
  }
  getOrganization(idd: number) {
    if (idd <= 0 || idd == undefined) {
      return "Have no any Oganization";
    }
    let orgName;
    if (this.lstCommon.lstOrganizations != undefined) {
      let obj = this.lstCommon.lstOrganizations.filter(x => {
        if (x.id == idd) {
          orgName = x.name
        }
      });
    }
    return orgName;
  }
  getShop(idd: number) {
    if (idd <= 0 || idd == undefined) {
      return "Have no any Shop";
    }
    let shopName;
    if (this.lstCommon.lstShops != undefined) {
      let obj = this.lstCommon.lstShops.filter(x => {
        if (x.id == idd) {
          shopName = x.name
        }
      });
    }
    return shopName;
  }
}

