import { Component, OnInit } from '@angular/core';
import { GetListRaceDto, GetRaceDto } from 'src/models/RaceInterfaces';
import { RaceService } from '../../../services/race.service';

@Component({
  selector: 'app-raceselector',
  templateUrl: './raceselector.component.html',
  styleUrls: ['./raceselector.component.css'],
})
export class RaceselectorComponent implements OnInit {
  _getListRacesDto: GetRaceDto[] = new Array<GetRaceDto>();
  lista = ['1','2','3'];
  constructor(private _raceService: RaceService) {}
  
  ngOnInit(): void {
    this.ReturnRace();
  }

  ReturnRace() {
    this._raceService.sendGetRequest().subscribe((res) => {
      this._getListRacesDto = res.data['getRacesDtos'];
      console.log(this.lista);
    });
  }
}
