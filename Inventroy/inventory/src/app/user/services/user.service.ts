import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { User, UserDetails } from '../models/user.model';
import { UserCreateRequest } from '../models/user-create-request.model';
import { SignUp } from '../models/sign-up.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/User/'
  }
  public get(): Observable<Array<User>>{
    return this.httpClient.get<Array<User>>(this.url);
  }
  public getByToken(model: UserCreateRequest): Observable<UserCreateRequest>{
    return this.httpClient.post<UserCreateRequest>(this.url + "getByToken", model, headerOption);
  }
  public getById(id: number): Observable<User>{
    return this.httpClient.get<User>(this.url + id, headerOption);
  }
  public post(model: UserCreateRequest): Observable<UserCreateRequest>{
    return this.httpClient.post<UserCreateRequest>(this.url , model, headerOption);
  }
  public signUp(model: SignUp): Observable<SignUp>{
    return this.httpClient.post<SignUp>(this.url +"signUp" , model, headerOption);
  }
  public put(model: User): Observable<User>{
    return this.httpClient.put<User>(this.url+'update', model, headerOption);
  }
  public delete(id: number): Observable<User>{
    return this.httpClient.delete<User>(this.url+'delete/' + id);
  }
  public GetDetails(id: number): Observable<UserDetails>{
    return this.httpClient.get<UserDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<UserDetails>>{
    return this.httpClient.get<Array<UserDetails>>(this.url + 'tableData');
  }
  public GetUserCreateData(): Observable<any>{
    return this.httpClient.get<any>(this.url + 'userCreateData');
  }
}