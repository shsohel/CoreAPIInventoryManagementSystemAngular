import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { EmployeeDocument } from '../model/employee.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EmployeeDocumentService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient) {
    this.url = this.appHost.hostName + 'api/EmployeeDocument/'
  }
  public get(): Observable<Array<EmployeeDocument>> {
    return this.httpClient.get<Array<EmployeeDocument>>(this.url);
  }
  public getById(id: number): Observable<EmployeeDocument> {
    return this.httpClient.get<EmployeeDocument>(this.url + id);
  }
  public post(model: any): Observable<any> {
    console.log(model)
    return this.httpClient.post<any>(this.url, model, headerOption);
  }
  public put(model: any): Observable<any> {
    return this.httpClient.put<any>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<EmployeeDocument> {
    return this.httpClient.delete<EmployeeDocument>(this.url + id);
  }
  public GetDetails(id: number): Observable<EmployeeDocument> {
    return this.httpClient.get<EmployeeDocument>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<EmployeeDocument>> {
    return this.httpClient.get<Array<EmployeeDocument>>(this.url + 'tableData');
  }
}