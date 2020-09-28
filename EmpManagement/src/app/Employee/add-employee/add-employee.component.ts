import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

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
  constructor(private empService:EmployeeService,private departService:DepartmentService,private router:Router) { }

  ngOnInit(): void {
    this.employee=this.initializeEmployees();
    this.depart=this.InitializeDepartment();

   /* this.empService.getEmployees().subscribe({
      next: employee => {
        this.employeeList = employee;
        this.employeeDetails = this.employeeList;
      },
     });*/
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
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }
    )

    /*if(employee.Eid==0)
    {
      this.insertEmployee(employee);
     //alert(employee.id);
    }
    /*else{
      this.updateEmployee(employee);
     // alert(employee.id);
    }*/

  }

  insertEmployee(employee:Employee){
    this.empService.addEmployee(employee).subscribe(
      res =>{
        alert(`employee successfully added`);
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }
    )
  }

  onSaveComplete(): void {

    this.router.navigate(['/employee']);
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

}
