import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDepartmentComponent } from './Department/add-department/add-department.component';
import { UpdateDepartmentComponent } from './Department/update-department/update-department.component';
import { ViewDepartmentListComponent } from './Department/view-department-list/view-department-list.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './Employee/update-employee/update-employee.component';
import { ViewEmployeeListComponent } from './Employee/view-employee-list/view-employee-list.component';
import { HomeComponent } from './home/home.component';
import { LoginPageComponent } from './Login/login-page/login-page.component';
import { WelcomeComponent } from './welcome/welcome.component';


const routes: Routes = [
  {path: 'welcome', component: WelcomeComponent},
  {path:'login', component: LoginPageComponent},
  {path:'home', component: HomeComponent},
  {path:'department', component: ViewDepartmentListComponent},
  {path:'employee', component: ViewEmployeeListComponent},
  {path:'addemployee/:id', component: AddEmployeeComponent},
  {path:'updateemployee/:id/edit', component: UpdateEmployeeComponent},
  {path:'adddepartment/:id', component: AddDepartmentComponent},
  {path:'updatedepartment/:id/edit', component: UpdateDepartmentComponent},
  { path: '', redirectTo: 'welcome', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
