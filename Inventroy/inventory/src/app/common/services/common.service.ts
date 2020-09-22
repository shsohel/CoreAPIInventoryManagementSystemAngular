import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseMessage } from '../models/response.message';
import { RequestMessage } from '../models/request.message';
import { AppHost } from '../models/app-host.model';
import { CommonDataList } from '../models/common-data-list.model';

// const HttpUploadOptions = {
//     headers: new HttpHeaders({ "Content-Type": "multipart/form-data" })
// }
const headerOption = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }
@Injectable({
    providedIn: 'root'
})
export class CommonService {
    // constructor(private http: HttpClient) { }
    // request = new RequestMessage();
    // url = "http://localhost:53336/api/ConmmonDataList/";

    // public GetConmmonDataList(tableName): Observable<ResponseMessage> {
    //     this.request.content = tableName;
    //     return this.http.post<ResponseMessage>(this.url + "getCommonDataList", this.request);
    // }
private appHost: AppHost = new AppHost();
  private url: string;
  constructor(private httpClient: HttpClient){
    this.url = this.appHost.hostName + 'api/CommonDataList/'
  }
  public get(): Observable<Array<CommonDataList>>{
    return this.httpClient.get<Array<CommonDataList>>(this.url+'commonDataList', headerOption);
  }
}
