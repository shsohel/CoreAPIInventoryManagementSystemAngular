import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeAddress } from '../model/employee.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EmployeeAddressService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/EmployeeAddress/'
  }
  public get(): Observable<Array<EmployeeAddress>>{
    return this.httpClient.get<Array<EmployeeAddress>>(this.url);
  }
  public getById(id: number): Observable<EmployeeAddress>{
    return this.httpClient.get<EmployeeAddress>(this.url + id);
  }
  public post(model: EmployeeAddress): Observable<EmployeeAddress>{
    console.log(model)
    return this.httpClient.post<EmployeeAddress>(this.url, model, headerOption);
  }
  public put(model: EmployeeAddress): Observable<EmployeeAddress>{
    return this.httpClient.put<EmployeeAddress>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<EmployeeAddress>{
    return this.httpClient.delete<EmployeeAddress>(this.url + id);
  }
  public GetDetails(id: number): Observable<EmployeeAddress>{
    return this.httpClient.get<EmployeeAddress>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<EmployeeAddress>>{
    return this.httpClient.get<Array<EmployeeAddress>>(this.url + 'tableData');
  }
}