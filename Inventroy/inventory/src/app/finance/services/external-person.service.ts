import { Injectable } from '@angular/core';
import { AppHost } from 'src/app/common/models/app-host.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ExternalPerson, ExternalPersonDetails } from '../models/external-person.model';

const headerOption = {
  headers: new HttpHeaders({
    'content-type': 'application/json'
  })
}

@Injectable()
export class ExternalPersonService{
  private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/ExternalPerson/'
  }
  public get(): Observable<Array<ExternalPerson>>{
    return this.httpClient.get<Array<ExternalPerson>>(this.url);
  }
  public getById(id: number): Observable<ExternalPerson>{
    return this.httpClient.get<ExternalPerson>(this.url + id);
  }
  public post(model: ExternalPerson): Observable<ExternalPerson>{
    console.log(model)
    return this.httpClient.post<ExternalPerson>(this.url, model, headerOption);
  }
  public put(model: ExternalPerson): Observable<ExternalPerson>{
    return this.httpClient.put<ExternalPerson>(this.url, model, headerOption);
  }
  public delete(id: number): Observable<ExternalPerson>{
    console.log(id);
    return this.httpClient.delete<ExternalPerson>(this.url + id);
  }
  public GetDetails(id: number): Observable<ExternalPersonDetails>{
    return this.httpClient.get<ExternalPersonDetails>(this.url + 'details/' + id);
  }
  public GetTableData(): Observable<Array<ExternalPersonDetails>>{
    return this.httpClient.get<Array<ExternalPersonDetails>>(this.url + 'tableData');
  }
}