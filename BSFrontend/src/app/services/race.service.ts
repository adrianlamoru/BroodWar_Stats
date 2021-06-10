import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ServiceResponse } from "src/models/ServiceResponseInterface";

@Injectable()
export class RaceService {
  private REST_API_SERVER = 'http://localhost:5000/api/race/getall';

  constructor(private httpClient: HttpClient) {}

  public sendGetRequest(): Observable<ServiceResponse> {
    return this.httpClient.get<ServiceResponse>(this.REST_API_SERVER);
  }
}
