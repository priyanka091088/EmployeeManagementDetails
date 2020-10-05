import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { HubConnectionBuilder } from '@aspnet/signalr';
import { Observable } from 'rxjs';
import { Department } from './Department.model';
import { Employee } from './Employee.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection
  emp:string;

  //messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  constructor() {
    this.createConnection();
    //this.registerOnServerEvents();
    this.startConnection();
   }

   public createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44368/NotificationHub')
      .build();

      //this.hubConnection.serverTimeoutInMilliseconds = 10000;
  }

  public startConnection = () => {
    this.hubConnection
      .start()
      .then(() =>{
        this.connectionIsEstablished = true;
        console.log('Hub connection started');

      })
      .catch(err => console.log('Error while starting connection: ' + err))
  }
  addEmployeeSendNotification(employee: Employee){
    return this.hubConnection.invoke('sendToUser', employee.Name,employee.Surname)
  }

  addDepartSendNotification(department:Department){
    return this.hubConnection.on('departAddNotify',(message:string) => {
      console.log("admin added new department");
    });

  }
  /*private registerOnServerEvents(): void {
    this.hubConnection.on('MessageReceived', (data: any) => {
      this.messageReceived.emit(data);
    });
  }  */
}
