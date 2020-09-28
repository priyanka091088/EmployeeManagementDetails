import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-view-department-list',
  templateUrl: './view-department-list.component.html',
  styleUrls: ['./view-department-list.component.css']
})
export class ViewDepartmentListComponent implements OnInit {
  public pageTitle:string="Department List";
  departDetails:Department[]=[];
  department:Department[];
  employee:Employee[];
  employeeDetails:Employee[]=[];
  constructor(private service:DepartmentService,private empService:EmployeeService,private router:Router) { }

  ngOnInit(): void {
    this.service.getDepartmentDetails().subscribe({
      next: depart => {
        this.department = depart;
        this.departDetails = this.department;
      },
     });

  }

  deleteDepartment(id){

    if (confirm(`Really delete the department?`)) {
    this.service.deleteDepartment(id).subscribe(
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
    this.service.getDepartmentDetails().subscribe({
      next: depart => {
        this.department = depart;
        this.departDetails = this.department;
      },
     });

   }

}
