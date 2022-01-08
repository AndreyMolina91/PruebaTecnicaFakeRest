import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'; //debe ser importado en el appmodule
import { Observable } from 'rxjs';
import { AuthorsInterface } from '../Interfaces/AuthorsInterface';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {
  //baseUrl con valor asignado de la web api
  baseUrl: string ="https://localhost:5001/api/Authors";

  constructor(private http: HttpClient) { }
  //Llamado del endpoint
  getAuthors(){
    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.http.get(this.baseUrl, {headers: headers});
  } //despues de llamado el endpoint en el service lo inyectamos en el componente authors

  postAuthors(author: AuthorsInterface){
    return this.http.post(this.baseUrl, author);
  }

  getColab(idBook: string): Observable<AuthorsInterface[]>{
    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
    return this.http.get<AuthorsInterface[]>(this.baseUrl+'/books/'+idBook, {headers: headers});
  }
} 