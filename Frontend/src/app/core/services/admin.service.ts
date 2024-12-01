import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment/environment';
import { User } from '../interfaces/user';
import { Observable } from 'rxjs';
import { CustomerFeedback } from '../interfaces/customerFeedback';
import { NewApplicationData } from '../interfaces/new-form-interfaces';
import { RenewApplicationData } from '../interfaces/form-interfaces';
import { IAdminApplicationData } from '../interfaces/adminApplicationData';
import { IUserList } from '../interfaces/userList';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private dbUrl = environment.apiUrl; 

  constructor(private http: HttpClient) { }

  GetAllUser = ():Observable<IUserList[]>=>{
    return this.http.get<IUserList[]>(`${this.dbUrl}/Admin/userlist`);
  }

  GetAllFeedback(): Observable<CustomerFeedback[]>{
    return this.http.get<CustomerFeedback[]>(`${this.dbUrl}/Admin/feedbacks`);
  }
  GetAllComplaint(): Observable<CustomerFeedback[]>{
    return this.http.get<CustomerFeedback[]>(`${this.dbUrl}/Admin/complaints`);
  }
  updateComplaint(complaint: CustomerFeedback): Observable<void> {
    return this.http.put<void>(`${this.dbUrl}/Admin/updateComplaint`, complaint);
  }

  getAllNewApplication(): Observable<IAdminApplicationData[]>{
    return this.http.get<IAdminApplicationData[]>(`${this.dbUrl}/Admin/newapplications`);
  }
  getAllRenewApplication(): Observable<IAdminApplicationData[]>{
    return this.http.get<IAdminApplicationData[]>(`${this.dbUrl}/Admin/renewapplications`);
  }
  updateApplicationStatus( applicationData : IAdminApplicationData): Observable<IAdminApplicationData> {
    return this.http.put<IAdminApplicationData>(`${this.dbUrl}/Admin/updateapplication`, applicationData);
  }
}
