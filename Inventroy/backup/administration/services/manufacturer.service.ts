import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { Manufacturer } from '../model/manufacturer.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Manufacturer/'
  }
  public get(): Observable<Array<Manufacturer>>{
    return this.httpClient.get<Array<Manufacturer>>(this.url);
  }
  public getById(id: number): Observable<Manufacturer>{
    return this.httpClient.get<Manufacturer>(this.url + id);
  }
  public post(model: Manufacturer): Observable<Manufacturer>{
    console.log(model)
    return this.httpClient.post<Manufacturer>(this.url, model, headerOption);
  }
  public put(model: Manufacturer): Observable<Manufacturer>{
    return this.httpClient.put<Manufacturer>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Manufacturer>{
    console.log(id);
    return this.httpClient.delete<Manufacturer>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<Manufacturer>{
    return this.httpClient.get<Manufacturer>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<Manufacturer>>{
    return this.httpClient.get<Array<Manufacturer>>(this.url + 'tableData');
  }
}
