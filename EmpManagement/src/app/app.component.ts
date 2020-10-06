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


    hubConnection.on('departAddNotify',function(message){
      alert(message);
      console.log(message);
    });


    hubConnection.on('employeeAddNotify',function(message){
      alert(message);
      console.log(message);
    });


    hubConnection.on('ProfileEditNotify',function(message){
      alert(message);
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
