import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee, EmployeeDetails } from '../model/employee.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Employee/'
  }
  public get(): Observable<Array<Employee>>{
    return this.httpClient.get<Array<Employee>>(this.url);
  }
  public getById(id: number): Observable<Employee>{
    return this.httpClient.get<Employee>(this.url + id);
  }
  public post(model: Employee): Observable<Employee>{
    console.log(model)
    return this.httpClient.post<Employee>(this.url, model, headerOption);
  }
  public put(model: Employee): Observable<Employee>{
    return this.httpClient.put<Employee>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Employee>{
    return this.httpClient.delete<Employee>(this.url + id);
  }
  public GetDetails(id: number): Observable<EmployeeDetails>{
    return this.httpClient.get<EmployeeDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<EmployeeDetails>>{
    return this.httpClient.get<Array<EmployeeDetails>>(this.url + 'tableData');
  }
}