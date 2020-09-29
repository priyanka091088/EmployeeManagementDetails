import { Injectable } from '@angular/core';
import { Observable, of, pipe, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Department } from './Department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
department:Department;
readonly rooturl='https://localhost:44368/api';
  list:Department[];
  constructor(private http:HttpClient) { }

  getDepartmentDetails():Observable<Department[]>{
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
    'Authorization':'Bearer '+localStorage.getItem('userToken')});
    return this.http.get<Department[]>(this.rooturl+'/DepartmentApi',{headers})
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addDepartment(department:Department){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
    'Authorization':'Bearer '+localStorage.getItem('userToken')});
    return this.http.post(this.rooturl+'/DepartmentApi',department,{headers});
   }

   deleteDepartment(id){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
    'Authorization':'Bearer '+localStorage.getItem('userToken')});
    return this.http.delete(this.rooturl+'/DepartmentApi/'+id,{headers});
   }

   updateDepartment(department:Department){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8',
    'Authorization':'Bearer '+localStorage.getItem('userToken')});
    return this.http.put(this.rooturl+'/DepartmentApi/'+department.DepartId,department,{headers});
   }

   getDepart(id: number): Observable<Department> {
    if (id === 0) {
      return of(this.initializeDepartment());
    }
    const url = `${this.rooturl+'/DepartmentApi'}/${id}`;
    return this.http.get<Department>(url)
      .pipe(
        tap(data => console.log('getDepartment: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }
  public initializeDepartment(): Department {
    // Return an initialized object
    return {
    DepartId:0,
    DepartName:''
    }
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
