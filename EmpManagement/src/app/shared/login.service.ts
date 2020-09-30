import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router,CanActivate,ActivatedRouteSnapshot } from '@angular/router';
import { Observable, pipe, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Login } from './Login.model';
import * as jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  readonly rooturl='https://localhost:44368/api/AuthenticateApi/login';
  isLoggedIn:boolean=false;

  constructor(private http:HttpClient,private router:Router) { }

  UserLogin(login:Login): void{
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
    'Authorization':'Bearer '+localStorage.getItem('userToken')});
    const as=JSON.stringify(login);

     this.http.post(this.rooturl,as, { headers:headers }).subscribe(
      (next:any)=>{
        console.log(next.token);
        localStorage.setItem('userToken',next.token)
        catchError(this.handleError),
        this.router.navigate(['/home',login.Email]);
      });


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

