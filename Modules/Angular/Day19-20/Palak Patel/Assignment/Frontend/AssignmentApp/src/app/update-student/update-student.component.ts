import { Component, OnInit } from '@angular/core';
import { IStudent } from 'src/Models/interfaces';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-update-student',
  templateUrl: './update-student.component.html',
  styleUrls: ['./update-student.component.css']
})
export class UpdateStudentComponent implements OnInit {

  StudentList : Array<IStudent>=[];
  isUpdating : boolean = false;

  constructor(public service : StudentService) {
    this.service.getstudents().subscribe(data=>this.StudentList = data);
   }

  submit(newStudent : IStudent){
    this.service.addStudent(newStudent).subscribe(data => {
      this.StudentList.push(data)
    });
  }

  isUpdatingStudent(event){
    this.isUpdating = event;
  }

  isUpdateingCompleted(event){
    this.isUpdating = event;
  }

  ngOnInit(): void {
  }

}
