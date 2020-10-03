import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:5001/image';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) {}

  getImage(id : number): Observable<any>{
    return this.http.get(baseUrl + "/" + id);
  }
}
