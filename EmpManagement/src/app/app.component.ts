import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as signalR from '@aspnet/signalr';
import { Observable } from 'rxjs';
import { LoginService } from './shared/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'EmployeeManagement';
  logintoken:string;

  ngOnInit(): void {
    this.logintoken=localStorage.getItem('userToken');

    var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub',{accessTokenFactory:() => this.logintoken})
    .build();


    hubConnection.on('departAddNotify',(name:string)=>{
      var message="New Department " + name + " Added By Admin";
      var li = document.createElement("li");
      li.textContent = message;
      var notifyMenu = document.getElementById("NotificationMenu");
      notifyMenu.appendChild(li);

      console.log(message);
    });


    hubConnection.on('employeeAddNotify',(name:string)=>{
      var message="New Employee " + name + " Was added By Admin";
      var li = document.createElement("li");
      li.textContent = message;
      var notifyMenu = document.getElementById("NotificationMenu");
      notifyMenu.appendChild(li);

      console.log(message);
    });


    hubConnection.on('ProfileEditNotify',(name:string)=>{
      var message=name + " Edited Their Profile";
      var li = document.createElement("li");
      li.textContent = message;
      var notifyMenu = document.getElementById("NotificationMenu");
      notifyMenu.appendChild(li);

      console.log(message);
    });

  try {
    hubConnection.start();
    console.log("Hub connection started");
} catch (err) {
    console.log(err);
}

  }



}
