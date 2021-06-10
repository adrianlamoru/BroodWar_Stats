export interface NewPlayerDto {
  RaceID: string;
  NickName: string;
  Name: string;
  LastName: string;
  CountryID: number;
  Age: number;
}

export interface GetPlayerListDto {
  GetPlayersDtos: GetPlayerDto[];
}

export interface GetPlayerDto {
  playerID: number;
  raceID: string;
  nickName: string;
  name: string;
  lastName: string;
  countryID: number;
  age: number;
}

export interface PlayerID{
  PlayerID: number;
}
