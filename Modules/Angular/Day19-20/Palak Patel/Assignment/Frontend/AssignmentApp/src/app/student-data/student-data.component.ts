import { Component, OnInit, Input, SimpleChanges, Output } from '@angular/core';
import { IStudent } from 'src/Models/interfaces';
import { EventEmitter } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-data',
  templateUrl: './student-data.component.html',
  styleUrls: ['./student-data.component.css']
})
export class StudentDataComponent implements OnInit {

  //@Input() studentData: Array<IStudent> = [];
  //isActiveInList : boolean = false;

  @Output() isUpdating : EventEmitter<any> = new EventEmitter;
  StudentList : IStudent[] = [];
  constructor(public service: StudentService) {
    this.service.getstudents().subscribe(data => this.StudentList = data);
   }

  ngOnInit(): void {
    //console.log(this.studentData);
  }

  UpdateStudent(student: IStudent, i:number){
    this.service.editStudent(student, i);
    this.isUpdating.emit(true);
  }

  // isActiveFunc(){
  //   this.isActiveInList = !this.isActiveInList;
  // }

  // ngOnChanges(changes: SimpleChanges): void {
  //   for(let property in changes){
  //     if(property === 'StudentList'){
  //       console.log("Previous : ", changes[property].previousValue);
  //       console.log("Current : ", changes[property].currentValue);
  //       console.log("firstChange : ", changes[property].firstChange);
  //     }
  //   }
  // }


}
