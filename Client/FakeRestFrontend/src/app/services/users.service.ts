import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UsersInterface } from '../Interfaces/UsersInterface';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl: string = 'https://localhost:5001/api/Users/Login';

  constructor(private http: HttpClient) { }

  userLogin(user: UsersInterface){
    return this.http.post(this.baseUrl, user);
  }

  get userConnected(){
    return localStorage.getItem('userName');
  }

  get userToken(){
    return !!localStorage.getItem('token_value');
  }
}
