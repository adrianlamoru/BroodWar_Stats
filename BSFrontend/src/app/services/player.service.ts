import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NewPlayerDto, PlayerID } from 'src/models/PlayerInterfaces';
import { ServiceResponse } from 'src/models/ServiceResponseInterface';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private REST_API_SERVER = 'http://localhost:5000/api';
  
  constructor(private httpClient: HttpClient) { }

  public newPlayerRequest(newPlayer: NewPlayerDto): Observable<ServiceResponse> {
    
    return this.httpClient.post<ServiceResponse>(this.REST_API_SERVER + '/player', newPlayer);
  }

  public getAllPlayers(): Observable<ServiceResponse> {
    
    return this.httpClient.get<ServiceResponse>(this.REST_API_SERVER + '/player/getall');
  }

  public deletePlayer(playerId: number): Observable<ServiceResponse> {
    return this.httpClient.delete<ServiceResponse>(this.REST_API_SERVER + '/player/' + playerId);
  }

  public getPlayerById(playerId: number): Observable<ServiceResponse> {
    return this.httpClient.get<ServiceResponse>(this.REST_API_SERVER + '/player/' + playerId);
  }
}
