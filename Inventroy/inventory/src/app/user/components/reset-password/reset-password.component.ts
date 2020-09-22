import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { PasswordReset } from '../../models/password-reset.model';
import { AppUserManagerService } from '../../services/app-user-manager.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DataService } from 'src/app/common/services/data.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  hide: boolean = true;
  passwordResetForm: FormGroup;
  passwordReset: PasswordReset = new PasswordReset();
  response: ResponseMessage = new ResponseMessage();

  constructor(private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder, 
    private appUserManagerService: AppUserManagerService, private router: Router,
    private matSnakBar: MatSnackBar, private dataService: DataService) {
    this.passwordResetForm = this.formBuilder.group({
      password: ['', [Validators.required, Validators.min(8)]],
      confirmPassword: ['', [Validators.required, Validators.min(8)]]
    })
  }

  ngOnInit() {
    this.passwordReset.token = this.activatedRoute.snapshot.queryParamMap.get('token');
    this.passwordReset.email = this.activatedRoute.snapshot.queryParamMap.get('email');
  }
  onResetPassword(){
    this.passwordReset.password = this.passwordResetForm.get('password').value;
    this.passwordReset.confirmPassword = this.passwordResetForm.get('confirmPassword').value;
    this.appUserManagerService.resetPassword(this.passwordReset).subscribe((res: any)=>{
      if(res.status == 200){
        this.response.message = res.message;
        this.dataService.setValueToResponseMessageProperty(this.response);
        this.router.navigateByUrl('/user/login');
      }
    }, e =>{
      this.matSnakBar.open(e.error.message, "Ok", {
        duration: 10000
      })
    })
  }
}
