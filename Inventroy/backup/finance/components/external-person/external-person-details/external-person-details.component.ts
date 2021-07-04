import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExternalPersonService } from 'src/app/finance/services/external-person.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-external-person-details',
  templateUrl: './external-person-details.component.html',
  styleUrls: ['./external-person-details.component.css']
})
export class ExternalPersonDetailsComponent implements OnInit {
  externalPersonId: number;
  externalPersonDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private externalTransferService: ExternalPersonService, private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(e => {
      this.externalPersonId = +e.get('id');
      if(this.externalPersonId != null){
        this.externalTransferService.GetDetails(this.externalPersonId).subscribe((res: any) => {
          this.externalPersonDetails = res.obj;
          console.log(this.externalPersonDetails);
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
