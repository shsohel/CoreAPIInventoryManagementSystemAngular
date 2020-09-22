import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UnitService } from 'src/app/administration/services/unit.service';
import { Unit } from 'src/app/administration/model/unit.model';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-unit-details',
  templateUrl: './unit-details.component.html',
  styleUrls: ['./unit-details.component.css']
})
export class UnitDetailsComponent implements OnInit {
  unitId: number;
  lstUnit: Unit = new Unit();
  unitDetails: any;
  constructor(private activatedRoute: ActivatedRoute, private unitService: UnitService, private matSnackBar: MatSnackBar, ) { }

  ngOnInit() {
    this.getUnitDetails();
  }
  getUnitDetails(): void {
    this.activatedRoute.paramMap.subscribe(e => {
      this.unitId = +e.get('id');
      if (this.unitId != null) {
        this.unitService.GetDetails(this.unitId).subscribe((res: any) => {
          this.unitDetails = res.obj;
          console.log(this.unitDetails)
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
}
