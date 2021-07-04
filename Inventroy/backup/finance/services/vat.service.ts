import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { VAT } from '../models/vat.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class VATService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/VAT/'
  }
  public get(): Observable<Array<VAT>>{
    return this.httpClient.get<Array<VAT>>(this.url);
  }
  public getById(id: number): Observable<VAT>{
    return this.httpClient.get<VAT>(this.url + id);
  }
  public post(model: VAT): Observable<VAT>{
    console.log(model)
    return this.httpClient.post<VAT>(this.url, model, headerOption);
  }
  public put(model: VAT): Observable<VAT>{
    return this.httpClient.put<VAT>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<VAT>{
    console.log(id);
    return this.httpClient.delete<VAT>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<VAT>{
    return this.httpClient.get<VAT>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<VAT>>{
    return this.httpClient.get<Array<VAT>>(this.url + 'tableData');
  }
}
