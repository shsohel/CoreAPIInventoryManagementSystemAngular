import { Component, OnInit } from '@angular/core';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { DataService } from 'src/app/common/services/data.service';
import { ProductionService } from 'src/app/administration/services/production.service';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-production-details',
  templateUrl: './production-details.component.html',
  styleUrls: ['./production-details.component.css']
})
export class ProductionDetailsComponent implements OnInit {
  productionId: number;
  lstCommon: CommonDataList = new CommonDataList();
  productionDetails: any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private activatedRoute: ActivatedRoute, private matSnackBar: MatSnackBar, private commonDataService: CommonService, private dataService: DataService,
    private prodcutionService: ProductionService) { }

  ngOnInit() {
    this.getProductDetails();
    this.commonDataService.get().subscribe((res: any) => {
      this.lstCommon = <CommonDataList>res.obj;
      console.log(this.lstCommon);
    })
  }
  getProductDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.productionId = +e.get('id');
      if (this.productionId != null) {
        this.prodcutionService.GetDetails(this.productionId).subscribe((res: any) => {
          this.productionDetails = res.obj;
          console.log(this.productionDetails)
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
  getOrganization(idd: number) {
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
