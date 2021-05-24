import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin_Controller,URLS } from 'src/app/Shared/Constants';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }
  ////### send Message by WhatsApp ###////
  GetAdmin(): Observable<any>{
    return this.http.get<any>(URLS.BaseUrl + Admin_Controller.GetAdmin);
  }
  NewAdmin(info): Observable<any>{
    return this.http.post<any>(URLS.BaseUrl + Admin_Controller.NewAdmin, info);
  }
  updateAdmin(updateinfo):Observable<any>{
    return this.http.put<any>(URLS.BaseUrl + Admin_Controller.UpdateAdmin ,updateinfo);
  }
  DeleteAdmin(adm_ID):Observable<any>{
   return this.http.delete<any>(URLS.BaseUrl+Admin_Controller.DeleteAdmin + adm_ID);
 }
}