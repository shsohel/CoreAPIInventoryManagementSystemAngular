import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Production } from '../model/production.model';
import { Observable } from 'rxjs';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ProductionService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Production/'
  }
  public get(): Observable<Array<Production>>{
    return this.httpClient.get<Array<Production>>(this.url);
  }
  public getById(id: number): Observable<Production>{
    return this.httpClient.get<Production>(this.url + id);
  }
  public post(model: Production): Observable<Production>{
    console.log(model)
    return this.httpClient.post<Production>(this.url, model, headerOption);
  }
  public put(model: Production): Observable<Production>{
    return this.httpClient.put<Production>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Production>{
    console.log(id);
    return this.httpClient.delete<Production>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<Production>{
    return this.httpClient.get<Production>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<Production>>{
    return this.httpClient.get<Array<Production>>(this.url + 'tableData');
  }
}
