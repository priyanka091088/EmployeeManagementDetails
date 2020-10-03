import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router,CanActivate,ActivatedRouteSnapshot } from '@angular/router';
import { Observable, pipe, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Login } from './Login.model';
import * as jwt_decode from 'jwt-decode';
import { ResetPassword } from './ResetPassword.model';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  readonly rooturl='https://localhost:44368/api/AuthenticateApi/login';
  readonly url='https://localhost:44368/api/AuthenticateApi/ForgotPassword';
  //isLoggedIn:boolean=false;

  constructor(private http:HttpClient,private router:Router) { }

  UserLogin(login:Login): void{

      const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
      'Authorization':'Bearer '+localStorage.getItem('userToken')});
      const as=JSON.stringify(login);

       this.http.post(this.rooturl,as, { headers:headers }).subscribe(
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

          catchError(this.handleError),
          this.router.navigate(['/home',login.Email]);
        });
  }

  isLoggedIn():boolean{
    if(localStorage.getItem('userToken')){
      return true;
    }
    else{
      return false;
    }
  }

  logOut(){
    if(this.isLoggedIn){
      localStorage.removeItem('userToken');
      this.router.navigate(['/welcome']);

    }
  }
  ResetPassword(resetpassword:ResetPassword){
    return this.http.post(this.url,resetpassword);

  }
  private handleError(err) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);

  }

}

