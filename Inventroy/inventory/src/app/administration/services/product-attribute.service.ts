import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { ProductAttribute } from '../model/product-attribute.model';
const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ProductAttributeService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/ProductAttribute/'
  }
  public get(): Observable<Array<ProductAttribute>>{
    return this.httpClient.get<Array<ProductAttribute>>(this.url);
  }
  public getById(id: number): Observable<ProductAttribute>{
    return this.httpClient.get<ProductAttribute>(this.url + id);
  }
  public post(model: any): Observable<any>{
    console.log(model)
    return this.httpClient.post<any>(this.url, model, headerOption);
  }
  public put(model: any): Observable<any>{
    return this.httpClient.put<any>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<ProductAttribute>{
    return this.httpClient.delete<ProductAttribute>(this.url+'delete/' + id);
  }
  public GetDetails(id: number): Observable<ProductAttribute>{
    return this.httpClient.get<ProductAttribute>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<ProductAttribute>>{
    return this.httpClient.get<Array<ProductAttribute>>(this.url + 'tableData');
  }
}