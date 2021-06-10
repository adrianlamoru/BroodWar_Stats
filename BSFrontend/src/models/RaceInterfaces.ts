export interface GetListRaceDto {
  getRacesDto: GetRaceDto[];
}

export interface GetRaceDto {
  raceID: string;
  name: string;
}
