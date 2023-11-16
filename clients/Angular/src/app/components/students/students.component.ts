import { Component } from '@angular/core';
import { IStudent } from 'src/app/models/IStudent';
import { StudentsService } from 'src/app/services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {
  students: IStudent[];

  constructor(private studentsService: StudentsService) {
    this.students = [];
  }

  ngOnInit(): void{
    this.studentsService.get().subscribe(result => {
      this.students = result;
    });
  }
}
