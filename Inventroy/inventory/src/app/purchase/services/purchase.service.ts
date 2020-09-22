import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PurchaseDetails, Purchase } from '../models/purchase.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class PurchaseService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Purchase/'
  }
  public get(): Observable<Array<Purchase>>{
    return this.httpClient.get<Array<Purchase>>(this.url);
  }
  public getById(id: number): Observable<Purchase>{
    return this.httpClient.get<Purchase>(this.url + id);
  }
  public post(model: Purchase): Observable<Purchase>{
    console.log(model)
    return this.httpClient.post<Purchase>(this.url, model, headerOption);
  }
  public put(model: Purchase): Observable<Purchase>{
    return this.httpClient.put<Purchase>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Purchase>{
    console.log(id);
    return this.httpClient.delete<Purchase>(this.url + id);
  }
  public GetDetails(id: number): Observable<PurchaseDetails>{
    return this.httpClient.get<PurchaseDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<PurchaseDetails>>{
    return this.httpClient.get<Array<PurchaseDetails>>(this.url + 'tableData');
  }
}