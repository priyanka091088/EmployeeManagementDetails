import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/shared/Employee.model';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css']
})
export class ViewProfileComponent implements OnInit {
  errorMessage:string;
  pageTitle:string = 'Profile';
  employee:Employee;

  constructor(private empService:EmployeeService,private route: ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.employee=this.initializeEmployee();
    const email=this.route.snapshot.paramMap.get('email');
    console.log(email);
    this.getEmpProfile(email);
  }

  Id:number;
  getEmpProfile(email:string):void{
    this.empService.getEmpProfile(email).subscribe({
         next:employee  => {this.onEmployeeRetrieved(employee);
        this.Id=employee.Eid},
         error:err => this.errorMessage=err
    });
}
  onEmployeeRetrieved(employee: Employee): void {
    this.employee = employee;

    if (!this.employee) {
      this.pageTitle = 'No Employee found';
      alert(`No Employee Found`);
      this.router.navigate(['/employeelogin']);

    } else {
      if (this.employee.Email === null) {
        this.pageTitle = 'No Employee With This Mail Id Exists';
        alert(`No Employee Found`);
        this.router.navigate(['/employeelogin']);


      } else {

        this.pageTitle = `Profile Of Employee: ${this.employee.Name}`;
      }
    }
  }
  private initializeEmployee(): Employee {
    // Return an initialized object
    return {
      Eid:0,
    Name:'',
    Surname:'',
    Address:'',
    Email:'',
    Qualification:'',
    ContactNo:'',
    DepartId:0,
    }
  }
}
