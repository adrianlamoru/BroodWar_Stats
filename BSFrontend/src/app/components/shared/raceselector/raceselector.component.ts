import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { GetListRaceDto, GetRaceDto } from 'src/models/RaceInterfaces';
import { RaceService } from '../../../services/race.service';

@Component({
  selector: 'app-raceselector',
  templateUrl: './raceselector.component.html',
  styleUrls: ['./raceselector.component.css'],
})
export class RaceselectorComponent implements OnInit {
  _getListRacesDto: GetRaceDto[] = new Array<GetRaceDto>();
  raceID: string;
  constructor(private _raceService: RaceService) {}

  ngOnInit(): void {
    this.ReturnRace();
  }
  @Output() onRaceID: EventEmitter<string> = new EventEmitter();

  ReturnRace() {
    this._raceService.sendGetRequest().subscribe((res) => {
      this._getListRacesDto = res.data['getRacesDtos'];
    });
  }

  returnRaceID() {
    this.onRaceID.emit(this.raceID);
  }
}
