import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VendorService } from 'src/app/sale/services/vendor.service';
import { VendorStatusCode } from 'src/app/sale/enums/vendor-satus-code.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-vendor-details',
  templateUrl: './vendor-details.component.html',
  styleUrls: ['./vendor-details.component.css']
})
export class VendorDetailsComponent implements OnInit {
  vendorId: number;
  vendorDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private vendorService: VendorService, private matSnackBar: MatSnackBar, ) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.vendorId = +e.get('id');
      if (this.vendorId != null) {
        this.vendorService.GetDetails(this.vendorId).subscribe((res: any) => {
          this.vendorDetails = res.obj;
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
      return VendorStatusCode[id];
    }
    return ""
  }
}
