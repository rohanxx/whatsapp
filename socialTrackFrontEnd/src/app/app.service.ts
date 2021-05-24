import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Accounts_Controller, Register_Controller, URLS } from './Shared/Constants';
@Injectable({
  providedIn: 'root'
})
export class AppService {
  constructor( private http:HttpClient) { }
  
  signin(loginData): Observable<any>{
     return this.http.post<any>(URLS.BaseUrl + Register_Controller.signin, loginData);
  }

  register(registerdata): Observable<any>{
     return this.http.post<any>(URLS.BaseUrl+Register_Controller.NewRegistation, registerdata);
  }

 getProfileData(id): Observable<any> {
   return this.http.get<any>(URLS.BaseUrl+Accounts_Controller.profile + id);
 }

 editProfile(profile): Observable<any> {
   return this.http.post<any>(URLS.BaseUrl+Accounts_Controller.editProfile, profile)
 }
}
