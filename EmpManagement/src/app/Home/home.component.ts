import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoginService } from '../shared/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'

})
export class HomeComponent implements OnInit {
  employeeEmail:string;
  constructor(private route: ActivatedRoute,private loginService:LoginService) { }

  ngOnInit(): void {
    const email=this.route.snapshot.paramMap.get('email');
    this.employeeEmail=email;
    console.log(this.employeeEmail);
  }
  logout(){
    this.loginService.logOut();
  }

}
