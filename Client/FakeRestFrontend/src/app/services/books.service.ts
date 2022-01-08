import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseUrl: string ="https://localhost:5001/api/Books";

  constructor(private http: HttpClient) { }

  getBooks(){
    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}` 
    })
    return this.http.get(this.baseUrl, {headers: headers}); 
  }

}
