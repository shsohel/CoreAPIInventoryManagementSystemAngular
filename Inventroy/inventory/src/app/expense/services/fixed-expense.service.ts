import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FixedExpense, FixedExpenseDetails } from '../models/fixed-expense.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class FixedExpenseService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/FixedExpense/'
  }
  public get(): Observable<Array<FixedExpense>>{
    return this.httpClient.get<Array<FixedExpense>>(this.url);
  }
  public getById(id: number): Observable<FixedExpense>{
    return this.httpClient.get<FixedExpense>(this.url + id);
  }
  public post(model: FixedExpense): Observable<FixedExpense>{
    console.log(model)
    return this.httpClient.post<FixedExpense>(this.url, model, headerOption);
  }
  public put(model: FixedExpense): Observable<FixedExpense>{
    return this.httpClient.put<FixedExpense>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<FixedExpense>{
    console.log(id);
    return this.httpClient.delete<FixedExpense>(this.url + id);
  }
  public GetDetails(id: number): Observable<FixedExpenseDetails>{
    return this.httpClient.get<FixedExpenseDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<FixedExpenseDetails>>{
    return this.httpClient.get<Array<FixedExpenseDetails>>(this.url + 'tableData');
  }
}