import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/sale/services/customer.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  customerId: number;
  customerDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private customerService: CustomerService, private matSnackBar: MatSnackBar, ) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.customerId = +e.get('id');
      if (this.customerId != null) {
        this.customerService.GetDetails(this.customerId).subscribe((res: any) => {
          this.customerDetails = res.obj;
          console.log(this.customerDetails)
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