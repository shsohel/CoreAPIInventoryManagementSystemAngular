import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppUserManagerService } from '../../services/app-user-manager.service';
import { Router } from '@angular/router';

import { AppHost } from 'src/app/common/models/app-host.model';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  forgetPasswordForm: FormGroup;
  appHost: AppHost = new AppHost();

  constructor(private formBuilder: FormBuilder, private appUserManagerService: AppUserManagerService,
    private router: Router, private dataService: DataService, private matSnakBar: MatSnackBar) { 
    this.forgetPasswordForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      link: ['', [Validators.required]]
    })
  }

  ngOnInit() {
  }
  showProgressBar;
  onSubmit(){
    this.showProgressBar = true;
    let link = this.appHost.clientHostName + "user/resetPassword?";
    this.forgetPasswordForm.get('link').setValue(link);
    this.appUserManagerService.forgetPassword(this.forgetPasswordForm.value).subscribe((res: any)=>{
      if(res.status == 200){
        this.matSnakBar.open(res.message, "Ok", {duration: 10000});
        this.forgetPasswordForm.reset();
        this.forgetPasswordForm.markAsUntouched();
        this.showProgressBar = false;
      }
    }, e =>{
      console.log(e.error);
      this.matSnakBar.open(e.error.message, "Ok", {duration: 10000});
      this.showProgressBar = false;
    })
  }
}
