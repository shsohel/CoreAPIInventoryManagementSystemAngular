import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { Organization, OrganizationDetails } from '../model/organization.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Organization/'
  }
  public get(): Observable<Array<Organization>>{
    return this.httpClient.get<Array<Organization>>(this.url);
  }
  public getById(id: number): Observable<Organization>{
    return this.httpClient.get<Organization>(this.url + id);
  }
  public post(model: Organization): Observable<Organization>{
    console.log(model)
    return this.httpClient.post<Organization>(this.url, model, headerOption);
  }
  public put(model: Organization): Observable<Organization>{
    return this.httpClient.put<Organization>(this.url, model, headerOption);
  }
  public delete(id: any): Observable<Organization>{
    return this.httpClient.delete<Organization>(this.url + id);
  }
  public GetDetails(id: number): Observable<Organization>{
    return this.httpClient.get<Organization>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<OrganizationDetails>>{
    return this.httpClient.get<Array<OrganizationDetails>>(this.url + 'tableData');
  }
}