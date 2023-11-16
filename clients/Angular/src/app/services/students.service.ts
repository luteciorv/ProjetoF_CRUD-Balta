import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IStudent } from '../models/IStudent';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  private readonly apiRoute: string = 'https://localhost:7106/api/alunos';
  
  constructor(private http: HttpClient) { 

  }

  get(): Observable<IStudent[]>{
    return this.http.get<IStudent[]>(this.apiRoute);
  };
}
