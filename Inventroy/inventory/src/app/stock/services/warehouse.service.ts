import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Warehouse, WarehouseDetails } from '../models/Warehouse.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class WarehouseService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Warehouse/'
  }
  public get(): Observable<Array<Warehouse>>{
    return this.httpClient.get<Array<Warehouse>>(this.url);
  }
  public getById(id: number): Observable<Warehouse>{
    return this.httpClient.get<Warehouse>(this.url + id);
  }
  public post(model: Warehouse): Observable<Warehouse>{
    return this.httpClient.post<Warehouse>(this.url, model, headerOption);
  }
  public put(model: Warehouse): Observable<Warehouse>{
    return this.httpClient.put<Warehouse>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Warehouse>{
    return this.httpClient.delete<Warehouse>(this.url + id);
  }
  public GetDetails(id: number): Observable<WarehouseDetails>{
    return this.httpClient.get<WarehouseDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<WarehouseDetails>>{
    return this.httpClient.get<Array<WarehouseDetails>>(this.url + 'tableData');
  }
}