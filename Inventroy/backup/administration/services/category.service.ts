import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { Category, CategoryDetails } from '../model/category.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/Category/'
  }
  public get(): Observable<Array<Category>>{
    return this.httpClient.get<Array<Category>>(this.url, headerOption);
  }
  public getById(id: number): Observable<Category>{
    return this.httpClient.get<Category>(this.url + id, headerOption);
  }
  public post(model: Category): Observable<Category>{
    console.log(model)
    return this.httpClient.post<Category>(this.url+'create', model, headerOption);
  }
  public put(model: Category): Observable<Category>{
    return this.httpClient.put<Category>(this.url+'update', model, headerOption);
  }
  public delete(id: any): Observable<Category>{
    return this.httpClient.delete<Category>(this.url+'delete/' + id);
  }
  public GetDetails(id: number): Observable<CategoryDetails>{
    return this.httpClient.get<CategoryDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<CategoryDetails>>{
    return this.httpClient.get<Array<CategoryDetails>>(this.url + 'tableData', headerOption);
  }
}