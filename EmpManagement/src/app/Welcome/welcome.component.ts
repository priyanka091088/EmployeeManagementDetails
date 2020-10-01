import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html'

})
export class WelcomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

    if(localStorage.getItem('userToken')){
      console.log("true");
    }
    else{
      console.log("false");
    }
  }

}
