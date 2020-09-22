import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Customer, CustomerDetails } from '../models/Customer.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class CustomerService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Customer/'
  }
  public get(): Observable<Array<Customer>>{
    return this.httpClient.get<Array<Customer>>(this.url);
  }
  public getById(id: number): Observable<Customer>{
    return this.httpClient.get<Customer>(this.url + id);
  }
  public post(model: Customer): Observable<Customer>{
    return this.httpClient.post<Customer>(this.url, model, headerOption);
  }
  public put(model: Customer): Observable<Customer>{
    return this.httpClient.put<Customer>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Customer>{
    return this.httpClient.delete<Customer>(this.url + id);
  }
  public GetDetails(id: number): Observable<CustomerDetails>{
    return this.httpClient.get<CustomerDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<CustomerDetails>>{
    return this.httpClient.get<Array<CustomerDetails>>(this.url + 'tableData');
  }
}