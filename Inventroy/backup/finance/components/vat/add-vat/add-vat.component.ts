import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VATService } from 'src/app/finance/services/vat.service';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { VAT } from 'src/app/finance/models/vat.model';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { YesOrNo } from 'src/app/administration/enums/yesorno.enum';
import { ResponseStatusCodeEnum } from 'src/app/common/enums/response-status-code.enum';

@Component({
  selector: 'app-add-vat',
  templateUrl: './add-vat.component.html',
  styleUrls: ['./add-vat.component.css']
})
export class AddVatComponent implements OnInit {
  vatModel: VAT = new VAT();
  addVATForm: FormGroup;
  reset: any = [{}];
  vATId: number;
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  yesOrNo = YesOrNo;
  keyOfYesNo: any = new Object();
  constructor(private _formBuilder: FormBuilder, private vatService:VATService,  private dataService: DataService,private matSnakBar: MatSnackBar,
    private router: Router, private activeRoute: ActivatedRoute) { 
      this.keyOfYesNo = Object.keys(this.yesOrNo).filter(Boolean);
      this.addVATForm = this._formBuilder.group({
         id: [''],
         name: ['',Validators.required],
         description:['',Validators.required],
         isPercent:['false', Validators.required],
         amount: ['',Validators.required],
         fromDate: ['',Validators.required],
         toDate: ['',Validators.required],
      })
    }

  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.vATId = +param.get("id");
      console.log(this.vATId)
      if (this.vATId > 0) {
        this.vatService.getById(this.vATId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          this.vatModel = suc.obj;
          this.addVATForm.patchValue(this.vatModel);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit(){
    this.vatModel = this.addVATForm.value;
    if (this.vATId > 0) {
      this.vatModel.id = this.vATId;
      this.vatService.put(this.vatModel).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.vatService.post(this.vatModel).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == ResponseStatusCodeEnum.Success) {
      this.dataService.setValueToResponseMessageProperty(this.response);

    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/finance/vatList");
    }
  }
}

