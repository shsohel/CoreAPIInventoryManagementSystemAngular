import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { Product } from '../model/product.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Product/'
  }
  public get(): Observable<Array<Product>>{
    return this.httpClient.get<Array<Product>>(this.url);
  }
  public getById(id: number): Observable<Product>{
    return this.httpClient.get<Product>(this.url + id);
  }
  public post(model: Product): Observable<Product>{
    console.log(model)
    return this.httpClient.post<Product>(this.url, model, headerOption);
  }
  public put(model: Product): Observable<Product>{
    return this.httpClient.put<Product>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<Product>{
    console.log(id);
    return this.httpClient.delete<Product>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<Product>{
    return this.httpClient.get<Product>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<Product>>{
    return this.httpClient.get<Array<Product>>(this.url + 'tableData');
  }
}

