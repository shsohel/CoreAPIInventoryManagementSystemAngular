import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BusinessRelativeService } from 'src/app/finance/services/business-relative.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-business-relative-details',
  templateUrl: './business-relative-details.component.html',
  styleUrls: ['./business-relative-details.component.css']
})
export class BusinessRelativeDetailsComponent implements OnInit {
  businessRelativeId: number;
  businessRelativeDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private businessRelativeService: BusinessRelativeService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.businessRelativeId = +e.get('id');
      if(this.businessRelativeId != null){
        this.businessRelativeService.GetDetails(this.businessRelativeId).subscribe((res: any) => {
          this.businessRelativeDetails = res.obj;
          console.log(this.businessRelativeDetails);
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