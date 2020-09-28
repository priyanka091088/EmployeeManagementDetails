import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, pipe, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

import { Employee } from './Employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  employee:Employee;
  readonly rooturl='https://localhost:44368/api';
  list:Employee[];

  constructor(private http:HttpClient) { }



  getEmployees():Observable<Employee[]>{
    return this.http.get<Employee[]>(this.rooturl+'/Employee')
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );

  }

  addEmployee(employee:Employee){
    return this.http.post(this.rooturl+'/Employee',employee);
   }

   deleteEmployee(id){
    return this.http.delete(this.rooturl+'/Employee/'+id);
   }

   updateEmployee(employee:Employee){
    return this.http.put(this.rooturl+'/Employee/'+employee.Eid,employee);
   }

   getEmp(id: number): Observable<Employee> {
    if (id === 0) {
      return of(this.initializeEmployee());
    }
    const url = `${this.rooturl+'/Employee'}/${id}`;
    return this.http.get<Employee>(url)
      .pipe(
        tap(data => console.log('getEmployee: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
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
UpdateEmployee(employee: Employee): Observable<Employee> {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  const url = `${this.rooturl+'/Employee'}/${employee.Eid}`;
  return this.http.put<Employee>(url, employee, { headers })
    .pipe(
      tap(() => console.log('updateEmployee: ' + employee.Eid)),
      // Return the product on an update
      map(() => employee),
      catchError(this.handleError)
    );
}

public initializeEmployee(): Employee {
  // Return an initialized object
  return {
    Eid:0,
  Name:'',
  Surname:'',
  Address:'',
  Email:'',
  Qualification:'',
  ContactNo:'',
  DepartId:0
  }
}
}
