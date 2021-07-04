import { Component, OnInit } from '@angular/core';
import { VendorStatusCode } from 'src/app/sale/enums/vendor-satus-code.enum';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vendor } from 'src/app/sale/models/vendor.model';
import { VendorService } from 'src/app/sale/services/vendor.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/common/services/data.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.css']
})
export class AddVendorComponent implements OnInit {
  vendor: Vendor = new Vendor();
  addVendorForm: FormGroup;
  reset: any = [{}];
  vendorId: number;
  //document: ImageDetails = new ImageDetails();
  response: ResponseMessage = new ResponseMessage();
  isDisable: boolean = false;
  constructor(private _formBuilder: FormBuilder, private vendorService: VendorService, private matSnakBar: MatSnackBar,
    private dataService: DataService, private router: Router, private activeRoute: ActivatedRoute) {
    this.addVendorForm = this._formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      guarantorId: ['', Validators.required],
      mobileNo: ['', Validators.required],
      email: ['', Validators.required],
      address: ['', Validators.required],
      registrationNo: ['', Validators.required],
      tin: ['', Validators.required],
      creditLimit: ['', Validators.required],
      discountPercent: [''],
      dayOfPayment: ['', Validators.required],
      picture: ['', Validators.required]
    })
  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(param => {
      this.vendorId = +param.get("id");
      console.log(this.vendorId)
      if (this.vendorId > 0) {
        this.vendorService.getById(this.vendorId).subscribe((suc: any) => {
          console.log("hi")
          console.log(suc);
          //console.log(suc.vendor)
          this.vendor = suc.obj;
          this.addVendorForm.patchValue(this.vendor);
        }, e => {
          this.matSnakBar.open(e.error.message, 'Ok', {
            duration: 10000
          })
        })
      }
    })
  }
  // onCardClick(id: string) {
  //   console.log(document.getElementById(id));
  //   (<HTMLElement>document.getElementById(id)).click();
  //   if (this.isDisable) {
  //     alert("You already upload picture for this Vendor. Please create this vendor first and edit later to change vendor picture")
  //   }
  // }
  onSubmit() {
    this.vendor = this.addVendorForm.value;
    if (this.vendorId > 0) {
      this.vendor.id = this.vendorId;
      this.vendorService.put(this.vendor).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
    else {
      this.vendorService.post(this.vendor).subscribe((res: any) => {
        this.workWithResponse(res);
      })
    }
  }
  workWithResponse(res: ResponseMessage) {
    this.response.message = res.message;
    this.response.statusCode = res.statusCode;
    if (this.response.statusCode == VendorStatusCode.drafted) {
      this.dataService.setValueToResponseMessageProperty(this.response);
      
    }
    else {
      this.matSnakBar.open(this.response.message, 'Ok', {
        duration: 10000
      })
      this.router.navigateByUrl("/sale/vendorList");
    }
  }
}