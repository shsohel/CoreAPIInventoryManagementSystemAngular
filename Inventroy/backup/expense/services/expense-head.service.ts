import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExpenseHead, ExpenseHeadDetails } from '../models/expense-Head.model';

const headerOption = {
    headers: new HttpHeaders({
        'content-Head': 'application/json'
    })
}

@Injectable()
export class ExpenseHeadService {
    private appHost: AppHost = new AppHost();
    private url: string;
    constructor(private httpClient: HttpClient) {
        this.url = this.appHost.hostName + 'api/ExpenseHead/'
    }
    public get(): Observable<Array<ExpenseHead>> {
        return this.httpClient.get<Array<ExpenseHead>>(this.url);
    }
    public getById(id: number): Observable<ExpenseHead> {
        return this.httpClient.get<ExpenseHead>(this.url + id);
    }
    public post(model: ExpenseHead): Observable<ExpenseHead> {
        console.log(model)
        return this.httpClient.post<ExpenseHead>(this.url, model, headerOption);
    }
    public put(model: ExpenseHead): Observable<ExpenseHead> {
        return this.httpClient.put<ExpenseHead>(this.url, model, headerOption);
    }
    public delete(id: number): Observable<ExpenseHead> {
        console.log(id);
        return this.httpClient.delete<ExpenseHead>(this.url + id);
    }
    public GetDetails(id: number): Observable<ExpenseHeadDetails> {
        return this.httpClient.get<ExpenseHeadDetails>(this.url + 'details/' + id);
    }
    public GetTableData(): Observable<Array<ExpenseHeadDetails>> {
        return this.httpClient.get<Array<ExpenseHeadDetails>>(this.url + 'tableData');
    }
}