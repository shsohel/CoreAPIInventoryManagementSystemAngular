import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Supplier, SupplierDetails } from '../models/supplier.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class SupplierService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Supplier/'
  }
  public get(): Observable<Array<Supplier>>{
    return this.httpClient.get<Array<Supplier>>(this.url);
  }
  public getById(id: number): Observable<Supplier>{
    return this.httpClient.get<Supplier>(this.url + id);
  }
  public post(model: Supplier): Observable<Supplier>{
    console.log(model)
    return this.httpClient.post<Supplier>(this.url, model, headerOption);
  }
  public put(model: Supplier): Observable<Supplier>{
    return this.httpClient.put<Supplier>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Supplier>{
    console.log(id);
    return this.httpClient.delete<Supplier>(this.url + id);
  }
  public GetDetails(id: number): Observable<SupplierDetails>{
    return this.httpClient.get<SupplierDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<SupplierDetails>>{
    return this.httpClient.get<Array<SupplierDetails>>(this.url + 'tableData');
  }
}