import {Department} from './Department.model'

export interface Employee{
  Eid:number;
  Name:string;
  Surname:string;
  Email:string;
  Address:string;
  Qualification:string;
  ContactNo:string;
  DepartId:number;
Department?:Department;

}
