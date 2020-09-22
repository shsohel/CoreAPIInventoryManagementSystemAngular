import { Component, OnInit } from '@angular/core';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from 'src/app/administration/services/shop.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.css']
})
export class ShopDetailsComponent implements OnInit {
  shopId: number;
  address: any;
  shopDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private shopService: ShopService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.shopId = +e.get('id');
      if (this.shopId != null) {
        this.shopService.GetDetails(this.shopId).subscribe((res: any) => {
          this.shopDetails = res.obj;
          this.address = this.shopDetails.address2;
          console.log(this.address)
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
}
