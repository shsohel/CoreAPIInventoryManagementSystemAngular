import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { SpecificationAttributeValue } from '../model/specification-attribute.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class SpecificationAttributeValueService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/SpecificationAttrValue/'
  }
  public get(): Observable<Array<SpecificationAttributeValue>>{
    return this.httpClient.get<Array<SpecificationAttributeValue>>(this.url);
  }
  public getById(id: number): Observable<SpecificationAttributeValue>{
    return this.httpClient.get<SpecificationAttributeValue>(this.url + id);
  }
  public post(model: any): Observable<any>{
    console.log(model)
    return this.httpClient.post<any>(this.url, model, headerOption);
  }
  public put(model: any): Observable<any>{
    return this.httpClient.put<any>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<SpecificationAttributeValue>{
    return this.httpClient.delete<SpecificationAttributeValue>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<SpecificationAttributeValue>{
    return this.httpClient.get<SpecificationAttributeValue>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<SpecificationAttributeValue>>{
    return this.httpClient.get<Array<SpecificationAttributeValue>>(this.url + 'tableData');
  }
}