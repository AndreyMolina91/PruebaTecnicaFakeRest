import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivitiesService } from '../services/activities.service';

@Component({
  selector: 'app-post-activities',
  templateUrl: './post-activities.component.html',
  styleUrls: ['./post-activities.component.css']
})
export class PostActivitiesComponent implements OnInit {

  //public para usarlo en el html
  constructor(public service: ActivitiesService, private router: Router) {}

  activityForm = new FormGroup({
    title: new FormControl('', Validators.required),
    dueDate: new FormControl('', Validators.required),
    completed: new FormControl('', Validators.required)
  })

  ngOnInit(): void {
  }

  onSubmit(){
    this.service.postActivity(this.activityForm.value).subscribe((data:any)=>{
      alert("Activity added on Web API SqlServer!");
      this.router.navigate(['/activities']);
    })
  }

}
