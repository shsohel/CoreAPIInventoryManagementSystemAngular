import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import { UserCreateRequest } from '../../models/user-create-request.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SignUp } from '../../models/sign-up.model';
import { AppUserManagerService } from '../../services/app-user-manager.service';
import { ResponseMessage } from 'src/app/common/models/response.message';
import { DataService } from 'src/app/common/services/data.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  hide: boolean = true;
  user: User = new User();
  userCreateRequest: UserCreateRequest = new UserCreateRequest();
  signUp: SignUp = new SignUp();
  hasToken: boolean = false;
  response: ResponseMessage = new ResponseMessage();
  signUpForm: FormGroup;
  constructor(private userService: UserService, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private appUserManagerService: AppUserManagerService, private router: Router, private dataService: DataService,
    private matSnakBar: MatSnackBar) { 
    this.signUpForm = this.formBuilder.group({
      userName: ['', Validators.required],
      employeeId: ['', [Validators.required]],
      email: ['', [Validators.required]],
      mobileNo: ['', [Validators.required]],
      userType: ['', Validators.required],
      password: ['', [Validators.required, Validators.min(8)]],
      confirmPassword: ['', [Validators.required, Validators.min(8)]],
    })
  }

  ngOnInit() {
    let token = this.activatedRoute.snapshot.queryParamMap.get('token');
    if(token != undefined){
      this.hasToken = true;
      this.userCreateRequest.varificationCode = token;
      this.userService.getByToken(this.userCreateRequest).subscribe((res: any)=>{
        this.user = res.obj;
        this.signUpForm.patchValue(this.user);
        console.log(this.user);
      })
    }
  }
  onSignUp(){
    if(this.signUpForm.valid){
      this.signUp = this.signUpForm.value;
      this.appUserManagerService.signUp(this.signUp).subscribe((res: any)=>{
        if(res.status == 200){
          this.response.message = res.message;
          this.dataService.setValueToResponseMessageProperty(this.response);
          this.router.navigateByUrl("/user/login");
        }
      }, e=>{
        this.matSnakBar.open(e.error.message, "Ok", {
          duration: 10000
        })
      })
    }
  }
}
