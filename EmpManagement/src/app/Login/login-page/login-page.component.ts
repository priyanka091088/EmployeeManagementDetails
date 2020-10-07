import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/shared/Login.model';
import { LoginService } from 'src/app/shared/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html'

})
export class LoginPageComponent implements OnInit {
  passwordInvalid:boolean=false;
  message:string;
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
    this.loginService.UserLogin(this.LoginDetails).subscribe(
      (next:any)=>{
        //console.log(next.token);
        localStorage.setItem('userToken',next.token)

        let token=localStorage.getItem('userToken');
        let jwtData=token.split('.')[1]
        let decodedJwtJsonData=window.atob(jwtData);
        let decodedJwtData=JSON.parse(decodedJwtJsonData);
        let roleName=decodedJwtData.role;
        localStorage.setItem('userRole',roleName);
        localStorage.setItem('userName',decodedJwtData.name);

        console.log("isrole: "+roleName);
        console.log("name: "+decodedJwtData.name);

       // catchError(this.handleError),
        this.router.navigate(['/home',localStorage.getItem('userName')]);
      },
       err=>{
        console.log(err);
        this.message="Invalid password";
        this.passwordInvalid=true;
      });
  }
}
