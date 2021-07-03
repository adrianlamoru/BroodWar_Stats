import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { PlayerService } from 'src/app/services/player.service';
import { GetPlayerDto, NewPlayerDto } from 'src/models/PlayerInterfaces';

@Component({
  selector: 'app-playerform',
  templateUrl: './playerform.component.html',
  styleUrls: ['./playerform.component.css'],
})
export class PlayerformComponent implements OnInit {
  playerForm: FormGroup = this.fb.group({
    NickName: [, [Validators.required, Validators.minLength(3)]],
    Name: [, [Validators.required, Validators.minLength(3)]],
    LastName: [, [Validators.required, Validators.minLength(3)]],
    RaceID: [],
    CountryID: [0],
    Age: [, [Validators.required, Validators.minLength(2)]],
    PlayerID: [0],
  });

  newPlayer: NewPlayerDto;
  _players: GetPlayerDto[] = new Array<GetPlayerDto>();
  _actualPlayerId: number = 0;

  constructor(private fb: FormBuilder, private playerService: PlayerService) {}

  ngOnInit(): void {
    /* this.playerForm.reset({
      NickName: '',
      Name: '',
      LastName: '',
      RaceID: '',
      CountryID: 0,
      Age: 0,
      PlayerID: 0,
    });*/
    this.GetAll();
  }

  save() {
    if (this.playerForm.invalid) {
      this.playerForm.markAllAsTouched();
      return;
    }
    this.newPlayer = this.playerForm.value;
    this.newPlayer.CountryID = +this.playerForm.value.CountryID;

    if (this.newPlayer.PlayerID === 0) {
      this.playerService.newPlayerRequest(this.newPlayer).subscribe((_) => {
        this.GetAll();
      });
    } else {
      this.playerService
        .updatePlayer(this.newPlayer.PlayerID, this.newPlayer)
        .subscribe((_) => {
          this.GetAll();
        });
    }
    this.playerForm.reset({
      NickName: '',
      Name: '',
      LastName: '',
      RaceID: '',
      CountryID: 0,
      Age: 0,
      PlayerID: 0,
    });
  }

  GetAll() {
    this.playerService.getAllPlayers().subscribe((res) => {
      this._players = res.data['playersDto'];
      console.log(this._players[0]);
    });
  }

  UpdatePlayerId(playerId: number) {
    this._actualPlayerId = playerId;
  }

  DeletePlayer() {
    this.playerService.deletePlayer(this._actualPlayerId).subscribe((_) => {
      this.GetAll();
    });
  }

  GetCountryID(countryID: number) {
    this.playerForm.patchValue({ CountryID: countryID });
  }

  GetRaceID(raceID: string) {
    this.playerForm.patchValue({ RaceID: raceID });
  }

  GetPlayerById(playerId: number) {
    let player: GetPlayerDto = this._players.find(
      (x) => x.playerID === playerId
    );
    this.playerForm.patchValue({ RaceID: player.raceID });
    this.playerForm.patchValue({ CountryID: player.countryID });
    this.playerForm.patchValue({ Name: player.name });
    this.playerForm.patchValue({ LastName: player.lastName });
    this.playerForm.patchValue({ NickName: player.nickName });
    this.playerForm.patchValue({ Age: player.age });
    this.playerForm.patchValue({ PlayerID: player.playerID });
    console.log(player.age);
  }
}
