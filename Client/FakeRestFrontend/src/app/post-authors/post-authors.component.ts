import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthorsService } from '../services/authors.service';

@Component({
  selector: 'app-post-authors',
  templateUrl: './post-authors.component.html',
  styleUrls: ['./post-authors.component.css']
})
export class PostAuthorsComponent {

  //inyectable del service de authors para el post
  //inyectable de router para usarlo en redirecciones
  constructor(private service: AuthorsService, 
    private router: Router) { }

  //definimos en la variable los campos que necesitamos utilizar en el fromulario del html
  authorsForm = new FormGroup({
    idBook: new FormControl('', Validators.required),
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required)
  })

  onSubmit(){
    this.service.postAuthors(this.authorsForm.value).subscribe((data:any)=>{
      alert("Authors created on Web API SqlServer!");
      this.router.navigate(['/authors']);
    })
  } 
}
