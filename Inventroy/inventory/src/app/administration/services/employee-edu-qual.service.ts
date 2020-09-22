import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { EmployeeEducationQual } from '../model/employee.model';
//import { CreateEduQual } from '../components/employee/add-employee/add-employee.component';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EmployeeEduQualService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/EmployeeEduQual/'
  }
  public get(): Observable<Array<EmployeeEducationQual>>{
    return this.httpClient.get<Array<EmployeeEducationQual>>(this.url);
  }
  public getById(id: number): Observable<EmployeeEducationQual>{
    return this.httpClient.get<EmployeeEducationQual>(this.url + id);
  }
  public post(model: any): Observable<any>{
    console.log(model)
    return this.httpClient.post<any>(this.url, model, headerOption);
  }
  public put(model: any): Observable<any>{
    return this.httpClient.put<any>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<EmployeeEducationQual>{
    return this.httpClient.delete<EmployeeEducationQual>(this.url + id);
  }
  public GetDetails(id: number): Observable<EmployeeEducationQual>{
    return this.httpClient.get<EmployeeEducationQual>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<EmployeeEducationQual>>{
    return this.httpClient.get<Array<EmployeeEducationQual>>(this.url + 'tableData');
  }
}