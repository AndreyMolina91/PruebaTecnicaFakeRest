import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-form-login',
  templateUrl: './form-login.component.html',
  styleUrls: ['./form-login.component.css']
})
export class FormLoginComponent {

  constructor(private service: UsersService, private router: Router) { }

  usersForm = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  })

  onSubmit(){
    this.service.userLogin(this.usersForm.value).subscribe((data:any)=>{
      localStorage.setItem('token_value', data.result.token);
      localStorage.setItem('userName', data.result.userName);
      alert(data.displayMessage); //arreglar el backend para que retorne un objeto result con username y token
      console.log(data.result);
      this.router.navigate(['/activities']);
      window.location.reload();
    },(errorData)=>alert(errorData.error.displayMessage));
    
  }

}
