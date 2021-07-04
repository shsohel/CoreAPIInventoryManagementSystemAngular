import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BankTransfer, BankTransferDetails } from '../models/bank-transfer.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class BankTransferService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/BankTransfer/'
  }
  public get(): Observable<Array<BankTransfer>>{
    return this.httpClient.get<Array<BankTransfer>>(this.url);
  }
  public getById(id: number): Observable<BankTransfer>{
    return this.httpClient.get<BankTransfer>(this.url + id);
  }
  public post(model: BankTransfer): Observable<BankTransfer>{
    console.log(model)
    return this.httpClient.post<BankTransfer>(this.url, model, headerOption);
  }
  public put(model: BankTransfer): Observable<BankTransfer>{
    return this.httpClient.put<BankTransfer>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<BankTransfer>{
    console.log(id);
    return this.httpClient.delete<BankTransfer>(this.url + id);
  }
  public GetDetails(id: number): Observable<BankTransferDetails>{
    return this.httpClient.get<BankTransferDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<BankTransferDetails>>{
    return this.httpClient.get<Array<BankTransferDetails>>(this.url + 'tableData');
  }
}