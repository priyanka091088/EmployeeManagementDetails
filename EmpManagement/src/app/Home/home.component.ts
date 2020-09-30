import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'

})
export class HomeComponent implements OnInit {
  employeeEmail:string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const email=this.route.snapshot.paramMap.get('email');
    this.employeeEmail=email;
    console.log(this.employeeEmail);
  }

}
