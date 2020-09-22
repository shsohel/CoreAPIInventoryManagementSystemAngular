import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { ProductItem } from '../model/product-item.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ProductItemService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/ProductItem/'
  }
  public get(): Observable<Array<ProductItem>>{
    return this.httpClient.get<Array<ProductItem>>(this.url);
  }
  public getById(id: number): Observable<ProductItem>{
    return this.httpClient.get<ProductItem>(this.url + id);
  }
  public post(model: ProductItem): Observable<ProductItem>{
    console.log(model)
    return this.httpClient.post<ProductItem>(this.url, model, headerOption);
  }
  public put(model: ProductItem): Observable<ProductItem>{
    return this.httpClient.put<ProductItem>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<ProductItem>{
    console.log(id);
    return this.httpClient.delete<ProductItem>(this.url+"delete/" + id);
  }
  public GetDetails(id: number): Observable<ProductItem>{
    return this.httpClient.get<ProductItem>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<ProductItem>>{
    return this.httpClient.get<Array<ProductItem>>(this.url + 'tableData');
  }
}
