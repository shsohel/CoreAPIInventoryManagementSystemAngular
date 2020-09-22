import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FixedExpenseSettingDetails, FixedExpenseSetting } from '../models/fixed-expense-setting.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class FixedExpenseSettingService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/FixedExpenseSetting/'
  }
  public get(): Observable<Array<FixedExpenseSetting>>{
    return this.httpClient.get<Array<FixedExpenseSetting>>(this.url);
  }
  public getById(id: number): Observable<FixedExpenseSetting>{
    return this.httpClient.get<FixedExpenseSetting>(this.url + id);
  }
  public post(model: FixedExpenseSetting): Observable<FixedExpenseSetting>{
    console.log(model)
    return this.httpClient.post<FixedExpenseSetting>(this.url, model, headerOption);
  }
  public put(model: FixedExpenseSetting): Observable<FixedExpenseSetting>{
    return this.httpClient.put<FixedExpenseSetting>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<FixedExpenseSetting>{
    return this.httpClient.delete<FixedExpenseSetting>(this.url + id);
  }
  public GetDetails(id: number): Observable<FixedExpenseSettingDetails>{
    return this.httpClient.get<FixedExpenseSettingDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<FixedExpenseSettingDetails>>{
    return this.httpClient.get<Array<FixedExpenseSettingDetails>>(this.url + 'tableData');
  }
}