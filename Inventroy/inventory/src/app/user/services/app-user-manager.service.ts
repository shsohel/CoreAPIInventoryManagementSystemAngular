import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { SignUp } from "../models/sign-up.model";
import { Login } from "../models/login.model";
import { PasswordReset } from "../models/password-reset.model";
import { AppHost } from "src/app/common/models/app-host.model";

const headerOption = {
  headers: new HttpHeaders({
    "content-type": "application/json",
  }),
};
@Injectable({
  providedIn: "root",
})
export class AppUserManagerService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient) {
    this.url = this.appHost.hostName + "api/AppUser/";
  }
  public signUp(model: SignUp): Observable<SignUp> {
    return this.httpClient.post<SignUp>(
      this.url + "signUp",
      model,
      headerOption
    );
  }
  public login(model: Login): Observable<Login> {
    return this.httpClient.post<Login>(this.url + "login", model, headerOption);
  }
  public forgetPassword(model: any): Observable<any> {
    return this.httpClient.post<any>(
      this.url + "forgetPassword",
      model,
      headerOption
    );
  }
  public resetPassword(model: PasswordReset): Observable<PasswordReset> {
    return this.httpClient.post<PasswordReset>(
      this.url + "resetPassword",
      model,
      headerOption
    );
  }
  public getDetails(): Observable<Login> {
    return this.httpClient.get<Login>(this.url + "getDetails");
  }
}
