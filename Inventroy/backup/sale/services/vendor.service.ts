import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vendor, VendorDetails } from '../models/vendor.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class VendorService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Vendor/'
  }
  public get(): Observable<Array<Vendor>>{
    return this.httpClient.get<Array<Vendor>>(this.url);
  }
  public getById(id: number): Observable<Vendor>{
    return this.httpClient.get<Vendor>(this.url + id);
  }
  public post(model: Vendor): Observable<Vendor>{
    console.log(model)
    return this.httpClient.post<Vendor>(this.url, model, headerOption);
  }
  public put(model: Vendor): Observable<Vendor>{
    return this.httpClient.put<Vendor>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Vendor>{
    return this.httpClient.delete<Vendor>(this.url + id);
  }
  public GetDetails(id: number): Observable<VendorDetails>{
    return this.httpClient.get<VendorDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<VendorDetails>>{
    return this.httpClient.get<Array<VendorDetails>>(this.url + 'tableData');
  }
}