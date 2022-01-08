import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-authors-by-book',
  templateUrl: './authors-by-book.component.html',
  styleUrls: ['./authors-by-book.component.css']
})
export class AuthorsByBookComponent implements OnInit {

  dataSource: any=[];
  displayedColumns: string[] = ['firstName','lastName']
  idBook: number;

  constructor(private dialogRef: MatDialogRef<AuthorsByBookComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {idBook: number, firstName: string, lastName: string}) 
    { 
      this.idBook = data.idBook;
      this.dataSource = data;
    }

  ngOnInit(): void {
  }
}