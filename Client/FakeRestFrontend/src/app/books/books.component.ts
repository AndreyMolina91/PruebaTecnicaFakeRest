import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { AuthorsByBookComponent } from '../authors-by-book/authors-by-book.component';
import { BooksInterface } from '../Interfaces/BooksInterface';
import { ActivitiesService } from '../services/activities.service';
import { AuthorsService } from '../services/authors.service';
import { BooksService } from '../services/books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  value = '';
  dataSource: any=[];
  displayedColumns: string[] = ['title','pageCount','publishDate','description','excerpt','colabs']
  
  
  constructor(private service: BooksService, 
    private serviceAuthors: AuthorsService, 
    private serviceActivities: ActivitiesService,
    private dialog: MatDialog
    ) 
    { } 

    

  ngOnInit(): void {
    this.service.getBooks().subscribe((data:any) => {
      this.dataSource = new MatTableDataSource<BooksInterface>(data as BooksInterface[]);
      console.log(data);
    });
  }

  getColabs(idBook: string){
    this.serviceAuthors.getColab(idBook).subscribe((data:any)=>{
      this.dialog.open(AuthorsByBookComponent, {
        data
      });
      console.log(data);
    });
  } 

  downloadCsv(): void{
    this.serviceActivities.getCsv(this.dataSource.filteredData, 'My_Books_List');
  }

  filtering(event: Event){
    const filter = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filter.trim().toLowerCase();
  }

}
