import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BankAccount, BankAccountDetails } from '../models/bank-account.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class BankAccountService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/BankAccount/'
  }
  public get(): Observable<Array<BankAccount>>{
    return this.httpClient.get<Array<BankAccount>>(this.url);
  }
  public getById(id: number): Observable<BankAccount>{
    return this.httpClient.get<BankAccount>(this.url + id);
  }
  public post(model: BankAccount): Observable<BankAccount>{
    console.log(model)
    return this.httpClient.post<BankAccount>(this.url, model, headerOption);
  }
  public put(model: BankAccount): Observable<BankAccount>{
    return this.httpClient.put<BankAccount>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<BankAccount>{
    console.log(id);
    return this.httpClient.delete<BankAccount>(this.url + id);
  }
  public GetDetails(id: number): Observable<BankAccountDetails>{
    return this.httpClient.get<BankAccountDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<BankAccountDetails>>{
    return this.httpClient.get<Array<BankAccountDetails>>(this.url + 'tableData');
  }
}