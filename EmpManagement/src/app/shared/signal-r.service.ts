import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { Employee } from './Employee.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection
  emp:string;
  constructor() { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:44368/api/Employee')
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addEmployeeSendNotification = (employee:Employee) => {
    this.hubConnection.on('transferchartdata', (data) => {
     // this.data = data;
      console.log("hello");
    });
  }

}
