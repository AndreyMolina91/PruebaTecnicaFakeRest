import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivitiesService } from '../services/activities.service';
import { ActivitiesInterface } from '../Interfaces/ActivitiesInterface';

@Component({
  selector: 'app-activities-table',
  templateUrl: './activities-table.component.html',
  styleUrls: ['./activities-table.component.css']
})
export class ActivitiesTableComponent implements OnInit {

  displayedColumns: string[]=['id','title','dueDate','completed','actions'];
  public dataSource = new MatTableDataSource<any>([]);
  @ViewChild(MatPaginator) private paginator: MatPaginator;

  constructor(private service: ActivitiesService) {}

  ngOnInit(): void {
    this.service.getActivities().subscribe((data:any) =>{
      this.dataSource = new MatTableDataSource<ActivitiesInterface>(data as ActivitiesInterface[]);
      this.dataSource.paginator = this.paginator;
    });
  }

  addToForm(element: ActivitiesInterface){
    console.log(element);
  }

} 
