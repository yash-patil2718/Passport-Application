import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  Observable } from 'rxjs';
import { environment } from '../../../environment/environment';
import { User } from '../interfaces/user';
import { ILoginCredential } from '../interfaces/ILoginCredential';
import { ILoggedUser } from '../interfaces/ILoggedUser';
import { IRegisterDto } from '../interfaces/IRegisterDto';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private dbUrl = environment.apiUrl; 
  //private dbUrl = 'http://localhost:3000/users';

  constructor(private http: HttpClient) { }

  signup(user: any): Observable<any> {
    return this.http.post(`${this.dbUrl}/users`, user);
  }

  GetAllUser = ():Observable<User[]>=>{
    return this.http.get<User[]>(`${this.dbUrl}/users`);
  }
  UpdateUser(user: User): Observable<User> {
    return this.http.put<User>(`${this.dbUrl}/users/${user.id}`, user);
  }

  DeleteUser(userId: number): Observable<void> {
    return this.http.delete<void>(`${this.dbUrl}/users/${userId}`);
  }

  Login(loginCredential : ILoginCredential): Observable<ILoggedUser>{
    return this.http.post<ILoggedUser>(`${this.dbUrl}/Auth/login`, loginCredential);
  }

  //register
  Register(registerData : IRegisterDto):Observable<void>{
    return this.http.post<void>(`${this.dbUrl}/Auth/register`, registerData);
  }

}
