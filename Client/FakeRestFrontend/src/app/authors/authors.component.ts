import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { AuthorsByBookComponent } from '../authors-by-book/authors-by-book.component';
import { AuthorsInterface } from '../Interfaces/AuthorsInterface';
import { AuthorsService } from '../services/authors.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  dataSource: any=[];
  displayedColumns: string[] = ['idBook','firstName','lastName','colabs']
  //Inyectamos el ClientService
  constructor(private service: AuthorsService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getAuthors().subscribe((data:any) => {
      this.dataSource = new MatTableDataSource<AuthorsInterface>(data as AuthorsInterface[]);
      console.log(data);
    });
  }

  getColabs(idBook: string){
    this.service.getColab(idBook).subscribe((data:any)=>{
      this.dialog.open(AuthorsByBookComponent, {
        data
      });
      console.log(data); 
    });
    
  }
 
}
