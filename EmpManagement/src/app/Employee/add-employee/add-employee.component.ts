import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import * as signalR from '@aspnet/signalr';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';
import { SignalRService } from 'src/app/shared/signal-r.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
public pageTitle:string="Add New Employee";
employee:Employee;
employeeDetails:Employee[]=[];
employeeList:Employee[];
depart:Department;
department:Department[];
departmentDetails:Department[]=[];
Id:number;
 empEmail=localStorage.getItem('userName');
  constructor(private empService:EmployeeService,private departService:DepartmentService,private router:Router,
    private signalrService:SignalRService,private http:HttpClient) { }

  ngOnInit(): void {

    this.employee=this.initializeEmployees();
    this.depart=this.InitializeDepartment();

    this.departService.getDepartmentDetails().subscribe({
      next: department=>{
        this.department=department;
        this.departmentDetails=this.department;
      }
    })
  }
  onSubmit(employee:Employee){
    this.empService.addEmployee(employee).subscribe(
      res =>{
        alert(`employee successfully added`);


       /* this.signalrService.createConnection();
        this.signalrService.startConnection();
        this.signalrService.addEmployeeSendNotification(employee);*/
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }
    )
  }

  onSaveComplete(): void {

    this.router.navigate(['/employee',this.empEmail]);
   }

  private initializeEmployees():Employee{
    return{
      Eid:0,
      Name:'',
      Surname:'',
      Email:'',
      Address:'',
      Qualification:'',
      ContactNo:'',
      DepartId:0,

    }

  }
  private InitializeDepartment():Department{
    return{
      DepartId:0,
      DepartName:''
    }
  }
  private startHttpRequest = () => {
    this.http.get('https://localhost:44368/api/Employee')
      .subscribe(res => {
        console.log(res);
      })
    }
}
