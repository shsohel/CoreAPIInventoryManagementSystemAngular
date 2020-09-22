import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Shop, ShopDetails } from '../model/shop.model';

const headerOption = {
    headers: new HttpHeaders({
        'content-type': 'application/json'
    })
}

@Injectable()
export class ShopService {
    private appHost: AppHost = new AppHost();
    private url: string;
    constructor(private httpClient: HttpClient) {
        this.url = this.appHost.hostName + 'api/Shop/'
    }
    public get(): Observable<Array<Shop>> {
        return this.httpClient.get<Array<Shop>>(this.url);
    }
    public getById(id: number): Observable<Shop> {
        return this.httpClient.get<Shop>(this.url + id);
    }
    public post(model: Shop): Observable<Shop> {
        console.log(model)
        return this.httpClient.post<Shop>(this.url, model, headerOption);
    }
    public put(model: Shop): Observable<Shop> {
        return this.httpClient.put<Shop>(this.url, model, headerOption);
    }
    public delete(id: number): Observable<Shop> {
        console.log(id);
        return this.httpClient.delete<Shop>(this.url + id);
    }
    public GetDetails(id: number): Observable<ShopDetails> {
        return this.httpClient.get<ShopDetails>(this.url + 'details/' + id);
    }
    public GetTableData(): Observable<Array<ShopDetails>> {
        return this.httpClient.get<Array<ShopDetails>>(this.url + 'tableData');
    }
}