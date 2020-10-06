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
    /*let isRole=localStorage.getItem('userRole');
    console.log(token);
    console.log(isRole);*/
    var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub',{accessTokenFactory:() => this.logintoken})
    .build();

    //hubConnection.start().then(function () {
    //console.log('Hub connection started');
    hubConnection.on('departAddNotify',function(message){
      alert(message);
      console.log(message);
    });

 /* var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub')
    .build();
    hubConnection.start().then(function () {
    console.log('Hub connection started');*/
    hubConnection.on('employeeAddNotify',function(message){
      alert(message);
      console.log(message);
    });

  /*var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44368/NotificationHub')
    .build();
    hubConnection.start().then(function () {
    console.log('Hub connection started');*/
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
