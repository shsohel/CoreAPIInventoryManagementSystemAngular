import { Component, OnInit } from '@angular/core';
import { ExternalPersonDetails } from 'src/app/finance/models/external-person.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ExternalPersonService } from 'src/app/finance/services/external-person.service';
import { CommonStatusEnum } from 'src/app/common/enums/common-status.enum';

@Component({
  selector: 'app-add-external-person',
  templateUrl: './add-external-person.component.html',
  styleUrls: ['./add-external-person.component.css']
})
export class AddExternalPersonComponent implements OnInit {
  externalPerson: ExternalPersonDetails = new ExternalPersonDetails();
  addExternalPersonForm: FormGroup;
  externalTransferId: number;
  response: ResponseMessage = new ResponseMessage();
  constructor(private _formBuilder: FormBuilder, private externalPersonService: ExternalPersonService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addExternalPersonForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      fathersName: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', Validators.required],
      address: ['', Validators.required],
      relationshipId: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.externalTransferId = +param.get("id");
      console.log(this.externalTransferId)
      if (this.externalTransferId > 0) {
        this.externalPersonService.getById(this.externalTransferId).subscribe((suc: any) => {
          this.externalPerson = suc.obj;
          this.addExternalPersonForm.patchValue(this.externalPerson);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  onSubmit() {
    this.externalPerson = this.addExternalPersonForm.value;
    if (this.externalTransferId > 0) {
      this.externalPerson.id = this.externalTransferId;
      this.externalPersonService.put(this.externalPerson).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.externalPersonService.post(this.externalPerson).subscribe((res: any) => {
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
      this.router.navigateByUrl("/finance/externalPersonList");
    }
  }
}