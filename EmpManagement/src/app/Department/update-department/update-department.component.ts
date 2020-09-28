import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Department } from 'src/app/shared/Department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-update-department',
  templateUrl: './update-department.component.html',
  styleUrls: ['./update-department.component.css']
})
export class UpdateDepartmentComponent implements OnInit {
  public pageTitle:string="Update Department";
  depart:Department;
  department:Department[];
  departmentDetails:Department[]=[];
  errorMessage:string;
  constructor(private empService:EmployeeService,private departService:DepartmentService,private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id=+this.route.snapshot.paramMap.get('id');
    this.getDepart(id);
    this.departService.getDepartmentDetails().subscribe({
      next: department=>{
        this.department=department;
        this.departmentDetails=this.department;
      }
    })

  }
  getDepart(id:number):void{
    this.departService.getDepart(id).subscribe({
         next:department  => this.onDepartmentRetrieved(department),
         error:err => this.errorMessage=err
    });
}

onDepartmentRetrieved(department:Department): void {
  this.depart = department;

  if (!this.depart) {
    this.pageTitle = 'No Employee found';
  } else {
    if (this.depart.DepartId === 0) {
      this.pageTitle = 'Add Employee';
    } else {
      this.pageTitle = `Edit Employee: ${this.depart.DepartName}`;
    }
  }
}
onSubmit(department:Department){
  this.departService.updateDepartment(department).subscribe(
    res =>{
      alert(`department successfully updated`);
      this.onSaveComplete();
    },
    err=>{
      console.log(err);
    }
  )
}
onSaveComplete(): void {

  this.router.navigate(['/department']);
 }


}
