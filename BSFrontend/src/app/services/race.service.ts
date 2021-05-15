import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { from } from 'rxjs';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { GetListRaceDto, ServiceResponse } from 'src/models/RaceInterfaces';

@Injectable()
export class RaceService {
  private REST_API_SERVER = 'http://localhost:5000/race/getall';

  constructor(private httpClient: HttpClient) {}

  public sendGetRequest(): Observable<ServiceResponse> {
    return this.httpClient.get<ServiceResponse>(this.REST_API_SERVER);
  }
}
