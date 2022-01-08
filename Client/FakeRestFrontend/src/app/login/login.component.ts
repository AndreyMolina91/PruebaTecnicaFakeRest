import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormLoginComponent } from '../form-login/form-login.component';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service: UsersService, private dialog: MatDialog) { }

  ngOnInit(): void {
    
  }

  getLoginForm(){
      this.dialog.open(FormLoginComponent);  
  } 

}
