import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InternalTransfer, InternalTransferDetails } from '../models/internal-transfer.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class InternalTransferService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/InternalTransfer/'
  }
  public get(): Observable<Array<InternalTransfer>>{
    return this.httpClient.get<Array<InternalTransfer>>(this.url);
  }
  public getById(id: number): Observable<InternalTransfer>{
    return this.httpClient.get<InternalTransfer>(this.url + id);
  }
  public post(model: InternalTransfer): Observable<InternalTransfer>{
    console.log(model)
    return this.httpClient.post<InternalTransfer>(this.url, model, headerOption);
  }
  public put(model: InternalTransfer): Observable<InternalTransfer>{
    return this.httpClient.put<InternalTransfer>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<InternalTransfer>{
    console.log(id);
    return this.httpClient.delete<InternalTransfer>(this.url + id);
  }
  public GetDetails(id: number): Observable<InternalTransferDetails>{
    return this.httpClient.get<InternalTransferDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<InternalTransferDetails>>{
    return this.httpClient.get<Array<InternalTransferDetails>>(this.url + 'tableData');
  }
}