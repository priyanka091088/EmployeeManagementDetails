import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {
  public pageTitle:string="Update Employee";
  employee:Employee;
  employeeDetails:Employee[]=[];
  employeeList:Employee[];
  depart:Department;
  department:Department[];
  departmentDetails:Department[]=[];
  errorMessage:string;
  constructor(private empService:EmployeeService,private departService:DepartmentService,private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.getEmp(id);
    this.departService.getDepartmentDetails().subscribe({
      next: department=>{
        this.department=department;
        this.departmentDetails=this.department;
      }
    })

  }

  getEmp(id:number):void{
    this.empService.getEmp(id).subscribe({
         next:employee  => this.onEmployeeRetrieved(employee),
         error:err => this.errorMessage=err
    });
}

onEmployeeRetrieved(employee: Employee): void {
  this.employee = employee;

  if (!this.employee) {
    this.pageTitle = 'No Employee found';
  } else {
    if (this.employee.Eid === 0) {
      this.pageTitle = 'Add Employee';
    } else {
      this.pageTitle = `Edit Employee: ${this.employee.Name}`;
    }
  }
}
  onSubmit(employee:Employee){
    this.empService.updateEmployee(employee).subscribe(
      res =>{
        alert(`employee successfully updated`);
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

}
