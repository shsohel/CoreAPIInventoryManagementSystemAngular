import { Component, OnInit } from '@angular/core';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { DataService } from 'src/app/common/services/data.service';
import { ProductItemService } from 'src/app/administration/services/product-item.service';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ProductType } from 'src/app/administration/enums/product-type.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-item-details',
  templateUrl: './product-item-details.component.html',
  styleUrls: ['./product-item-details.component.css']
})
export class ProductItemDetailsComponent implements OnInit {
  productItemId: number;
  lstCommon: CommonDataList = new CommonDataList();
  productItemDetails: any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private activatedRoute: ActivatedRoute, private matSnackBar: MatSnackBar, private commonDataService: CommonService,private dataService: DataService,
    private productItemService: ProductItemService) { }

  ngOnInit() {
    this.getProductItemDetails();
    this.commonDataService.get().subscribe((res: any) => {
      this.lstCommon = <CommonDataList>res.obj;
      console.log(this.lstCommon);
    })
  }
  getProductItemDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.productItemId = +e.get('id');
      if (this.productItemId != null) {
        this.productItemService.GetDetails(this.productItemId).subscribe((res: any) => {
          this.productItemDetails = res.obj;
          console.log(this.productItemDetails)
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
  getProductType(id: number): string {
    if (id != 0) {
      return ProductType[id];
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

