import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { SpecificationAttribute } from '../model/specification-attribute.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class SpecificationAttributeService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/SpecificationAttribute/'
  }
  public get(): Observable<Array<SpecificationAttribute>>{
    return this.httpClient.get<Array<SpecificationAttribute>>(this.url);
  }
  public getById(id: number): Observable<SpecificationAttribute>{
    return this.httpClient.get<SpecificationAttribute>(this.url + id);
  }
  public post(model: SpecificationAttribute): Observable<SpecificationAttribute>{
    console.log(model)
    return this.httpClient.post<SpecificationAttribute>(this.url, model, headerOption);
  }
  public put(model: SpecificationAttribute): Observable<SpecificationAttribute>{
    return this.httpClient.put<SpecificationAttribute>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<SpecificationAttribute>{
    console.log(id);
    return this.httpClient.delete<SpecificationAttribute>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<SpecificationAttribute>{
    return this.httpClient.get<SpecificationAttribute>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<SpecificationAttribute>>{
    return this.httpClient.get<Array<SpecificationAttribute>>(this.url + 'tableData');
  }
}
