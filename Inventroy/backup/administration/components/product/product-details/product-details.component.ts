import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/administration/model/category.model';
import { ActivatedRoute } from '@angular/router';
import { CommonService } from 'src/app/common/services/common.service';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { ProductService } from 'src/app/administration/services/product.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  productId: number;
  lstCommon: CommonDataList = new CommonDataList();
  productDetails: any;
  response: ResponseMessage = new ResponseMessage();
  constructor(private activatedRoute: ActivatedRoute, private matSnackBar: MatSnackBar, private commonDataService: CommonService,private dataService: DataService,
    private prodcutService: ProductService) { }

  ngOnInit() {
    this.getProductDetails();
    this.commonDataService.get().subscribe((res: any) => {
      this.lstCommon = <CommonDataList>res.obj;
      console.log(this.lstCommon);
    })
  }
  getProductDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.productId = +e.get('id');
      if (this.productId != null) {
        this.prodcutService.GetDetails(this.productId).subscribe((res: any) => {
          this.productDetails = res.obj;
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
