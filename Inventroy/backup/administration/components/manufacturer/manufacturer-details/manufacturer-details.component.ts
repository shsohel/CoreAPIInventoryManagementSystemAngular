import { Component, OnInit } from '@angular/core';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { ManufacturerService } from 'src/app/administration/services/manufacturer.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manufacturer-details',
  templateUrl: './manufacturer-details.component.html',
  styleUrls: ['./manufacturer-details.component.css']
})
export class ManufacturerDetailsComponent implements OnInit {
  manufacturerId: number;
  lstCommon: CommonDataList = new CommonDataList();
  manufacturerDetails: any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private activatedRoute: ActivatedRoute, private matSnackBar: MatSnackBar, private dataService: DataService,private commonDataService: CommonService,
    private manufacturerService: ManufacturerService) { }

  ngOnInit() {
    this.getCategoryDetails();
    this.commonDataService.get().subscribe((res: any) => {
      this.lstCommon = <CommonDataList>res.obj;
      console.log(this.lstCommon);
    })
  }
  getCategoryDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.manufacturerId = +e.get('id');
      if (this.manufacturerId != null) {
        this.manufacturerService.GetDetails(this.manufacturerId).subscribe((res: any) => {
          this.manufacturerDetails = res.obj;
          console.log(this.manufacturerDetails);
          this.workWithResponse(res);
        })
      }
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
  getCategory(idd: number) {
    //console.log('parentid: '+idd)
    if (idd <= 0 || idd == undefined) {
      return "Have no any Category";
    }
    let categoryName;
    if (this.lstCommon.lstCategories != undefined) {
      let obj = this.lstCommon.lstCategories.filter(x => {
        if (x.id == idd) {
          categoryName = x.name
        }
      });
    }
    return categoryName;
  }
  getOrganization(idd: number) {
    //console.log('parentid: '+idd)
    if (idd <= 0 || idd == undefined) {
      return "Have no any Category";
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
    //console.log('parentid: '+idd)
    if (idd <= 0 || idd == undefined) {
      return "Have no any Category";
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
