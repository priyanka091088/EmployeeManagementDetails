import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LoginPageComponent } from './Login/login-page/login-page.component';
//Employee CRUD Components
import { ViewEmployeeListComponent } from './Employee/view-employee-list/view-employee-list.component';
import { UpdateEmployeeComponent } from './Employee/update-employee/update-employee.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
//Department CRUD Components
import { AddDepartmentComponent } from './Department/add-department/add-department.component';
import { UpdateDepartmentComponent } from './Department/update-department/update-department.component';
import { ViewDepartmentListComponent } from './Department/view-department-list/view-department-list.component';
import { HomeComponent } from './home/home.component';
//Services
import { EmployeeService } from './shared/employee.service';
import { DepartmentService } from './shared/department.service';
import { LoginService } from './shared/login.service';
import { ViewProfileComponent } from './EmployeeProfile/view-profile/view-profile.component';
import { EditProfileComponent } from './EmployeeProfile/edit-profile/edit-profile.component';


@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    LoginPageComponent,
    ViewEmployeeListComponent,
    UpdateEmployeeComponent,
    AddEmployeeComponent,
    AddDepartmentComponent,
    UpdateDepartmentComponent,
    ViewDepartmentListComponent,
    HomeComponent,
    ViewProfileComponent,
    EditProfileComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [
    EmployeeService,
    DepartmentService,
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
