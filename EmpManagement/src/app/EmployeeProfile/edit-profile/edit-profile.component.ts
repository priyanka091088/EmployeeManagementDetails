import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  public pageTitle:string="Update Employee";
  employee:Employee;
  employeeDetails:Employee[]=[];
  employeeList:Employee[];
  errorMessage:string;
  constructor(private empService:EmployeeService,private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.initializeEmployees();
    const id=+this.route.snapshot.paramMap.get('id');
    this.getEmp(id);
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
  this.empService.UpdateEmployeeProfile(employee).subscribe(
    res =>{
      alert(`profile successfully updated`);
      this.onSaveComplete(employee);
    },
    err=>{
      console.log(err);
    }
  )
}
onSaveComplete(employee:Employee): void {

  this.router.navigate(['/employee',employee.Email]);
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
}
