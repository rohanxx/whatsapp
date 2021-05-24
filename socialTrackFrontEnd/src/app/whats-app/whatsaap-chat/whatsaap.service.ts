import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accounts_Controller,WhatsApp_Controller,Contact_Controller,URLS } from 'src/app/Shared/Constants';

@Injectable({
  providedIn: 'root'
})
export class WhatsaapService {

  constructor(private http:HttpClient) { }
  ////### send Message by WhatsApp ###////
  sendmessage(data): Observable<any>{ debugger
    return this.http.post<any>(URLS.BaseUrl + WhatsApp_Controller.sendmessage, data);
  }
  getchat(): Observable<any>{
    return this.http.get<any>(URLS.BaseUrl + WhatsApp_Controller.getchat);
  }
  getChatByNumber(ToNum):Observable<any>{
    return this.http.get<any>(URLS.BaseUrl + WhatsApp_Controller.getChatByNumber + ToNum);
  }
 newPhoneNumber(details):Observable<any>{
   return this.http.post<any>(URLS.BaseUrl+Contact_Controller.Contact, details);
 }
}
