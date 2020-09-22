import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GeneralExpense, GeneralExpenseDetails } from '../models/general-expense.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class GeneralExpenseService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/GeneralExpense/'
  }
  public get(): Observable<Array<GeneralExpense>>{
    return this.httpClient.get<Array<GeneralExpense>>(this.url);
  }
  public getById(id: number): Observable<GeneralExpense>{
    return this.httpClient.get<GeneralExpense>(this.url + id);
  }
  public post(model: GeneralExpense): Observable<GeneralExpense>{
    console.log(model)
    return this.httpClient.post<GeneralExpense>(this.url, model, headerOption);
  }
  public put(model: GeneralExpense): Observable<GeneralExpense>{
    return this.httpClient.put<GeneralExpense>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<GeneralExpense>{
    console.log(id);
    return this.httpClient.delete<GeneralExpense>(this.url + id);
  }
  public GetDetails(id: number): Observable<GeneralExpenseDetails>{
    return this.httpClient.get<GeneralExpenseDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<GeneralExpenseDetails>>{
    return this.httpClient.get<Array<GeneralExpenseDetails>>(this.url + 'tableData');
  }
}