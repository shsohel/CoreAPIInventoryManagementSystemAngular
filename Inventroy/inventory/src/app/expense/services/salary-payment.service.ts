import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SalaryPayment, SalaryPaymentDetails } from '../models/salary-payment.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class SalaryPaymentService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/SalaryPayment/'
  }
  public get(): Observable<Array<SalaryPayment>>{
    return this.httpClient.get<Array<SalaryPayment>>(this.url);
  }
  public getById(id: number): Observable<SalaryPayment>{
    return this.httpClient.get<SalaryPayment>(this.url + id);
  }
  public post(model: SalaryPayment): Observable<SalaryPayment>{
    console.log(model)
    return this.httpClient.post<SalaryPayment>(this.url, model, headerOption);
  }
  public put(model: SalaryPayment): Observable<SalaryPayment>{
    return this.httpClient.put<SalaryPayment>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<SalaryPayment>{
    console.log(id);
    return this.httpClient.delete<SalaryPayment>(this.url + id);
  }
  public GetDetails(id: number): Observable<SalaryPaymentDetails>{
    return this.httpClient.get<SalaryPaymentDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<SalaryPaymentDetails>>{
    return this.httpClient.get<Array<SalaryPaymentDetails>>(this.url + 'tableData');
  }
}