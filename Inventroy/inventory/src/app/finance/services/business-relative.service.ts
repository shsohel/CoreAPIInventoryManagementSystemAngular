import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BusinessRelative, BusinessRelativeDetails } from '../models/business-relative.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class BusinessRelativeService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/BusinessRelative/'
  }
  public get(): Observable<Array<BusinessRelative>>{
    return this.httpClient.get<Array<BusinessRelative>>(this.url);
  }
  public getById(id: number): Observable<BusinessRelative>{
    return this.httpClient.get<BusinessRelative>(this.url + id);
  }
  public post(model: BusinessRelative): Observable<BusinessRelative>{
    console.log(model)
    return this.httpClient.post<BusinessRelative>(this.url, model, headerOption);
  }
  public put(model: BusinessRelative): Observable<BusinessRelative>{
    return this.httpClient.put<BusinessRelative>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<BusinessRelative>{
    console.log(id);
    return this.httpClient.delete<BusinessRelative>(this.url + id);
  }
  public GetDetails(id: number): Observable<BusinessRelativeDetails>{
    return this.httpClient.get<BusinessRelativeDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<BusinessRelativeDetails>>{
    return this.httpClient.get<Array<BusinessRelativeDetails>>(this.url + 'tableData');
  }
}