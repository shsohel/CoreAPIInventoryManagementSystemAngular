import { Component, OnInit } from '@angular/core';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ExternalTransferService } from 'src/app/finance/services/external-transfer.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ExternalTransferDetails } from 'src/app/finance/models/external-transfer.model';

@Component({
  selector: 'app-add-external-tansfer',
  templateUrl: './add-external-tansfer.component.html',
  styleUrls: ['./add-external-tansfer.component.css']
})
export class AddExternalTansferComponent implements OnInit {
  externalTransfer: ExternalTransferDetails = new ExternalTransferDetails();
  addExternalTransferForm: FormGroup;
  reset: any = [{}];
  externalTransferId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private externalTransferService: ExternalTransferService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addExternalTransferForm = this._formBuilder.group({
      id: [''],
      externalPersonName: ['', Validators.required],
      amount: ['', Validators.required],
      note: ['', Validators.required],
      requestedBy: [''],
      capturedBy: ['', Validators.required],
      capturedDate: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.externalTransferId = +param.get("id");
      console.log(this.externalTransferId)
      if (this.externalTransferId > 0) {
        this.externalTransferService.getById(this.externalTransferId).subscribe((suc: any) => {
          this.externalTransfer = suc.obj;
          this.addExternalTransferForm.patchValue(this.externalTransfer);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.externalTransfer = this.addExternalTransferForm.value;
    if (this.externalTransferId > 0) {
      this.externalTransfer.id = this.externalTransferId;
      this.externalTransferService.put(this.externalTransfer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.externalTransferService.post(this.externalTransfer).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == CommonStatusEnum.Active) {
      this.dataService.setValueToResponseMessageProperty(this.response);
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/finance/externalTransferList");
    }
  }
}