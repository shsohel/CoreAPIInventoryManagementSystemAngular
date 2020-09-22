import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PayIncentive, PayIncentiveDetails } from '../models/pay-incentive.module';

const headerOption = {
    headers: new HttpHeaders({
        'content-Head': 'application/json'
    })
}

@Injectable()
export class PayIncentiveService {
    private appHost: AppHost = new AppHost();
    private url: string;
    constructor(private httpClient: HttpClient) {
        this.url = this.appHost.hostName + 'api/PayIncentive/'
    }
    public get(): Observable<Array<PayIncentive>> {
        return this.httpClient.get<Array<PayIncentive>>(this.url);
    }
    public getById(id: number): Observable<PayIncentive> {
        return this.httpClient.get<PayIncentive>(this.url + id);
    }
    public post(model: PayIncentive): Observable<PayIncentive> {
        console.log(model)
        return this.httpClient.post<PayIncentive>(this.url, model, headerOption);
    }
    public put(model: PayIncentive): Observable<PayIncentive> {
        return this.httpClient.put<PayIncentive>(this.url, model, headerOption);
    }
    public delete(id: number): Observable<PayIncentive> {
        console.log(id);
        return this.httpClient.delete<PayIncentive>(this.url + id);
    }
    public GetDetails(id: number): Observable<PayIncentiveDetails> {
        return this.httpClient.get<PayIncentiveDetails>(this.url + 'details/' + id);
    }
    public GetTableData(): Observable<Array<PayIncentiveDetails>> {
        return this.httpClient.get<Array<PayIncentiveDetails>>(this.url + 'tableData');
    }
}