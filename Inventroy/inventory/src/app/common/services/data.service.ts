import { Injectable, EventEmitter } from "@angular/core";
import { ResponseMessage } from '../models/response.message';
import { Observable } from 'rxjs';

@Injectable()
export class DataService{

    showProgressBarEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
    isShowProgressBar: boolean;
    onProgress(isShow: boolean){
        this.isShowProgressBar = isShow;
        this.loginEvent.emit(this.isShowProgressBar);
    }

    loginEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
    isLoggedIn: boolean = false;
    onLoggedIn(isLoggedIns: boolean){
        this.isLoggedIn = isLoggedIns;
        this.loginEvent.emit(this.isLoggedIn);
    }
    responseMessageEvent: EventEmitter<ResponseMessage> = new EventEmitter<ResponseMessage>();
    responseMessageData: ResponseMessage;
    setValueToResponseMessageProperty(data: ResponseMessage){
        this.responseMessageData = data;
        this.responseMessageEvent.emit(this.responseMessageData);
    }
}