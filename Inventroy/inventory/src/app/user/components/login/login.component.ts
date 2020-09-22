import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/common/services/data.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppUserManagerService } from '../../services/app-user-manager.service';
import { Login } from '../../models/login.model';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide: boolean = true;
  loginForm: FormGroup;
  login: Login = new Login();

  constructor(private dataService: DataService, private matSnakBar: MatSnackBar, private formBuilder: FormBuilder,
    private appUserManagerService: AppUserManagerService, private router: Router) { 
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  ngOnInit() {
    if(this.dataService.responseMessageData != null){
      this.matSnakBar.open(this.dataService.responseMessageData.message, "Ok", {duration: 10000});
      this.dataService.setValueToResponseMessageProperty(null);
    }
    if(localStorage.getItem('iMSToken') != null){
      this.router.navigateByUrl("/");
    }
    else{
      if(this.dataService.responseMessageData != null){
        this.matSnakBar.open(this.dataService.responseMessageData.message, "Ok", {
          duration: 10000
        });
        this.dataService.setValueToResponseMessageProperty(null);
      }
    }
  }
  onLogin(){
    this.loginForm.markAllAsTouched();
    if(this.loginForm.valid){
      this.login = this.loginForm.value;
      this.appUserManagerService.login(this.login).subscribe((res: any)=>{
        if(res.status == 200){
          localStorage.setItem('iMSToken', res.iMSToken);
          this.dataService.onLoggedIn(true);
          this.router.navigateByUrl("/");
        }
      }, e=> {
        this.matSnakBar.open(e.error.message, "Ok", {
          duration: 10000
        })
      })
    }
  }
}
