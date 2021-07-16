import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { IStudent } from 'src/Models/interfaces';
import { Observable, of } from 'rxjs';
import { catchError, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  httpUrl : string;
  httpOptions = {
    headers : new HttpHeaders({'Content-Type': 'applcation.json'})
  };
  selectedStudent : IStudent;
  selectedStudentID: number;

  constructor(private http: HttpClient) {
    this.httpUrl = "https://localhost:44382/api/StudentDetails"
   }

  get getSelectedStudent(){
    return this.selectedStudent;
  }

  get getSelectedStudentId(){
    return this.selectedStudentID;
  }

  ClearSelectedStudent(){
    this.selectedStudent = undefined;
  }

  ClearSelectedStudentId(){
    this.selectedStudentID = undefined;
  }

  getstudents():Observable<IStudent[]>{
    return this.http.get<IStudent[]>(this.httpUrl);
  }

  getStudent(id: number):Observable<IStudent>{
    return this.http.get<IStudent>(`${this.httpUrl}/${id}`);
  } 

  addStudent(student: IStudent): Observable<IStudent>{
    return this.http.post(this.httpUrl, student).pipe(
      tap((student:IStudent)=> console.log(`New student : ${student}`)),
      catchError(this.handleError<IStudent>('addStudent'))
    );
  }

  updateStudent(id:number, student: IStudent): Observable<any>{
    student.studentId=id;
    return this.http.put(`${this.httpUrl}/${id}`, student).pipe(
      catchError(this.handleError<IStudent>('updateStudent'))
    );
  }

  editStudent(st: IStudent, i:number){
    this.selectedStudent = st;
    console.log(i);
    this.getStudent(i).subscribe(data => {
      this.selectedStudentID = data.studentId
    });
    console.log(this.selectedStudentID);
  }

  deleteStudent(id:number) : Observable<IStudent>{
    return this.http.delete<IStudent>(`${this.httpUrl}/${id}`).pipe(
      catchError(this.handleError<IStudent>('deletedStudent'))
    );
  }
  
  private handleError<T>(operation='operation', result? : T) {
    return (error:any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed : ${error.message}`);
      return of(result as T);
    }
  }

}

