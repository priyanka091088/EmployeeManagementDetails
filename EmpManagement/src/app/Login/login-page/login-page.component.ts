import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/shared/Login.model';
import { LoginService } from 'src/app/shared/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'

})
export class LoginPageComponent implements OnInit {

  constructor(private loginService:LoginService,private router:Router) { }

  LoginDetails:Login={
    Email:'',
    Password:''
  };
public employeeEmail:string;
  ngOnInit(): void {
  }

  Login(){
console.log(this.LoginDetails);
    this.loginService.UserLogin(this.LoginDetails)
  }
}
