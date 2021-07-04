import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExpenseType, ExpenseTypeDetails } from '../models/expense-type.model';

const headerOption = {
    headers: new HttpHeaders({
        'content-type': 'application/json'
    })
}

@Injectable()
export class ExpenseTypeService {
    private appHost: AppHost = new AppHost();
    private url: string;
    constructor(private httpClient: HttpClient) {
        this.url = this.appHost.hostName + 'api/ExpenseType/'
    }
    public get(): Observable<Array<ExpenseType>> {
        return this.httpClient.get<Array<ExpenseType>>(this.url);
    }
    public getById(id: number): Observable<ExpenseType> {
        return this.httpClient.get<ExpenseType>(this.url + id);
    }
    public post(model: ExpenseType): Observable<ExpenseType> {
        console.log(model)
        return this.httpClient.post<ExpenseType>(this.url, model, headerOption);
    }
    public put(model: ExpenseType): Observable<ExpenseType> {
        return this.httpClient.put<ExpenseType>(this.url, model, headerOption);
    }
    public delete(id: number): Observable<ExpenseType> {
        console.log(id);
        return this.httpClient.delete<ExpenseType>(this.url + id);
    }
    public GetDetails(id: number): Observable<ExpenseTypeDetails> {
        return this.httpClient.get<ExpenseTypeDetails>(this.url + 'details/' + id);
    }
    public GetTableData(): Observable<Array<ExpenseTypeDetails>> {
        return this.httpClient.get<Array<ExpenseTypeDetails>>(this.url + 'tableData');
    }
}