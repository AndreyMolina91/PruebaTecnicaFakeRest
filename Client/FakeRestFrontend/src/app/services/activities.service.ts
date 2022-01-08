import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivitiesInterface } from '../Interfaces/ActivitiesInterface';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet; charset=UTF-8';
const EXCEL_EXT = '.xlsx';

@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {

  // Objeto a enviar entre componentes Table a Form en activities
  activityObject: any = {};
  //My api
  baseUrl: string ='https://localhost:5001/api/FakeRest';

  constructor(private http: HttpClient) { } 

  getActivities(){
    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}` 
    })
    return this.http.get(this.baseUrl+'/Activities', {headers: headers});
  }

  getCsv(json:any[], excelFileName: string): void{
    const workSheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
    const workBook: XLSX.WorkBook = {
      Sheets: {'data': workSheet},
      SheetNames: ['data']
    }
    const excelBuffer: any = XLSX.write(workBook, {bookType: 'xlsx', type: 'array'});
    
    this.saveAsExcel(excelBuffer, excelFileName);

    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}` 
    })
    this.http.get(this.baseUrl+'/csv', {headers: headers, responseType: `blob` as `json`});
  }

  postActivity(activity: ActivitiesInterface){
    let token = localStorage.getItem('token_value');
    const headers = new HttpHeaders({
      'Content-type': 'application/json',
      'Authorization': `Bearer ${token}` 
    })
    return this.http.post(this.baseUrl+'/Activities', activity);
  }

  private saveAsExcel(buffer: any, fileName: string): void{
    const data: Blob = new Blob([buffer], {type: EXCEL_TYPE});
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXT);
  }



}
