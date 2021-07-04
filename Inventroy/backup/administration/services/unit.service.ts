import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { Unit } from '../model/unit.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class UnitService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Unit/'
  }
  public get(): Observable<Array<Unit>>{
    return this.httpClient.get<Array<Unit>>(this.url, headerOption);
  }
  public getById(id: number): Observable<Unit>{
    return this.httpClient.get<Unit>(this.url + id, headerOption);
  }
  public post(model: Unit): Observable<Unit>{
    console.log(model)
    return this.httpClient.post<Unit>(this.url+'create', model, headerOption);
  }
  public put(model: Unit): Observable<Unit>{
    return this.httpClient.put<Unit>(this.url+'update', model, headerOption);
  }
  public delete(id: any): Observable<Unit>{
    return this.httpClient.delete<Unit>(this.url+'delete/' + id);
  }
  public GetDetails(id: number): Observable<Unit>{
    return this.httpClient.get<Unit>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<Unit>>{
    return this.httpClient.get<Array<Unit>>(this.url + 'tableData', headerOption);
  }
}