import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExternalTransfer, ExternalTransferDetails } from '../models/external-transfer.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class ExternalTransferService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/ExternalTransfer/'
  }
  public get(): Observable<Array<ExternalTransfer>>{
    return this.httpClient.get<Array<ExternalTransfer>>(this.url);
  }
  public getById(id: number): Observable<ExternalTransfer>{
    return this.httpClient.get<ExternalTransfer>(this.url + id);
  }
  public post(model: ExternalTransfer): Observable<ExternalTransfer>{
    console.log(model)
    return this.httpClient.post<ExternalTransfer>(this.url, model, headerOption);
  }
  public put(model: ExternalTransfer): Observable<ExternalTransfer>{
    return this.httpClient.put<ExternalTransfer>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<ExternalTransfer>{
    console.log(id);
    return this.httpClient.delete<ExternalTransfer>(this.url + id);
  }
  public GetDetails(id: number): Observable<ExternalTransferDetails>{
    return this.httpClient.get<ExternalTransferDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<ExternalTransferDetails>>{
    return this.httpClient.get<Array<ExternalTransferDetails>>(this.url + 'tableData');
  }
}