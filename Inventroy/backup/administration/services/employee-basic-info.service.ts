import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { EmployeeBasicInfo } from '../model/employee.model';
import { Observable } from 'rxjs';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EmployeeBasicInfoService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient) {
    this.url = this.appHost.hostName + 'api/EmployeeBasicInfo/'
  }
  public get(): Observable<Array<EmployeeBasicInfo>> {
    return this.httpClient.get<Array<EmployeeBasicInfo>>(this.url);
  }
  public getById(id: number): Observable<EmployeeBasicInfo> {
    return this.httpClient.get<EmployeeBasicInfo>(this.url + id);
  }
  public post(model: EmployeeBasicInfo): Observable<EmployeeBasicInfo> {
    console.log(model)
    return this.httpClient.post<EmployeeBasicInfo>(this.url, model, headerOption);
  }
  public put(model: EmployeeBasicInfo): Observable<EmployeeBasicInfo> {
    return this.httpClient.put<EmployeeBasicInfo>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<EmployeeBasicInfo> {
    return this.httpClient.delete<EmployeeBasicInfo>(this.url + id);
  }
  public GetDetails(id: number): Observable<EmployeeBasicInfo> {
    return this.httpClient.get<EmployeeBasicInfo>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<EmployeeBasicInfo>> {
    return this.httpClient.get<Array<EmployeeBasicInfo>>(this.url + 'tableData');
  }
}