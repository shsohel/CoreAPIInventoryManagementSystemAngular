import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { ActivatedRoute } from '@angular/router';
import { VATService } from 'src/app/finance/services/vat.service';
import { VAT } from 'src/app/finance/models/vat.model';
import { CommonService } from 'src/app/common/services/common.service';
import { CommonDataList } from 'src/app/common/models/common-data-list.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-vat-details',
  templateUrl: './vat-details.component.html',
  styleUrls: ['./vat-details.component.css']
})
export class VatDetailsComponent implements OnInit {
  vatId: number;
  commonDataList: CommonDataList = new CommonDataList();
  lstVat: VAT = new VAT();
  vatDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private vatService: VATService, private matSnackBar: MatSnackBar, private commonService: CommonService ) { }

  ngOnInit() {
    this.getUnitDetails();
    this.commonService.get().subscribe((res: any) => {
      this.commonDataList = <CommonDataList>res.obj;
      console.log(this.commonDataList);
    })
  }
  getUnitDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.vatId = +e.get('id');
      if (this.vatId != null) {
        this.vatService.GetDetails(this.vatId).subscribe((res: any) => {
          this.vatDetails = res.obj;
          console.log(this.vatDetails)
        }, e => {
          this.matSnackBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  getStatus(id: number): string {
    if (id != 0) {
      return CommonStatusEnum[id];
    }
    return ""
  }
  getYesNo(name: string): string {
  //  console.log(name)
    if (name !=null) {
      return YesOrNo[name];
    }
    return ""
  }
  getOrgName(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonDataList.lstOrganizations != undefined) {
      let obj = this.commonDataList.lstOrganizations.filter(x => {
        if (x.id == id) {
          nam = x.name
        }
      });
    }
    return nam;
  }
  getShopName(id: number) {
    if (id <= 0 || id == undefined) {
      return "";
    }
    let nam;
    if (this.commonDataList.lstShops != undefined) {
      let obj = this.commonDataList.lstShops.filter(x => {
        if (x.id == id) {
          nam = x.name
        }
      });
    }
    return nam;
  }
}

