import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnInit {
  public pageTitle:string="Add New Employee";
  depart:Department;
department:Department[];
departmentDetails:Department[]=[];
empEmail=localStorage.getItem('userName');
  constructor(private departService:DepartmentService,private router:Router) { }

  ngOnInit(): void {
    this.depart=this.InitializeDepartment();

    this.departService.getDepartmentDetails().subscribe({
      next: department=>{
        this.department=department;
        this.departmentDetails=this.department;
      }
    })
  }
  onSubmit(department:Department){
    this.departService.addDepartment(department).subscribe(
      res =>{
        alert(`Department successfully added`);
        this.onSaveComplete();
      },
      err=>{
        console.log(err);
      }
    )
  }
  onSaveComplete(): void {

    this.router.navigate(['/department',this.empEmail]);
   }
  private InitializeDepartment():Department{
    return{
      DepartId:0,
      DepartName:''
    }
  }

}
