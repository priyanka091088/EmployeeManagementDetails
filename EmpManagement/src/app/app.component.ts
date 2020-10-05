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

  ngOnInit(): void {
    var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub')
    .build();
    hubConnection.start().then(function () {
    console.log('Hub connection started');
    hubConnection.on('departAddNotify',function(message){
      console.log(message);
    });
  });

  var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub')
    .build();
    hubConnection.start().then(function () {
    console.log('Hub connection started');
    hubConnection.on('employeeAddNotify',function(message){
      console.log(message);
    });
  });

  var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub')
    .build();
    hubConnection.start().then(function () {
    console.log('Hub connection started');
    hubConnection.on('ProfileEditNotify',function(message){
      console.log(message);
    });
  });

  }



}
