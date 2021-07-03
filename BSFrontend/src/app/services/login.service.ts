import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/models/ServiceResponseInterface';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private REST_API_SERVER = 'http://localhost:5000/api/auth/login';
  constructor(private httpClient: HttpClient) { }

  public getToken(): Observable<ServiceResponse> {
    return this.httpClient.get<ServiceResponse>(
      this.REST_API_SERVER 
    );
  }
}
