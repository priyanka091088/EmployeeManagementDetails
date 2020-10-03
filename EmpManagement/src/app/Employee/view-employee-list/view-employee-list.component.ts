import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-view-employee-list',
  templateUrl: './view-employee-list.component.html'

})
export class ViewEmployeeListComponent implements OnInit {
  public pageTitle:string="Employee List";
emp:Employee;
  employeedetails:Employee[]=[];
  employee:Employee[];
  depart:Department;
  department:Department[];
  departmentDetails:Department[]=[];

  employeeEmail=localStorage.getItem('userName');
  constructor(private service:EmployeeService,private depService:DepartmentService,private router:Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.emp=this.initializeEmployee();

    this.service.getEmployees().subscribe({
      next: employee => {
        this.employee = employee;
        if(localStorage.getItem('userRole')=="Employee"){
          this.emp=this.employee.find(e=>e.Email==this.employeeEmail);
          this.employee=employee.filter(e=>e.DepartId==this.emp.DepartId);
          this.employeedetails=this.employee;

        }
        this.employeedetails = this.employee;
      },
     });

  }
  DeleteEmployee(id){
    if (confirm(`Really delete the employee?`)) {
    this.service.deleteEmployee(id).subscribe(
      res =>{

        this.onSaveComplete();

      },
      err=>{
        console.log(err);
      }
    )
  }
  }

  onSaveComplete(): void {
    this.service.getEmployees().subscribe({
      next: employee => {
        this.employee = employee;
        this.employeedetails = this.employee;
      },
     });

   }
   private initializeEmployee():Employee{
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

}
