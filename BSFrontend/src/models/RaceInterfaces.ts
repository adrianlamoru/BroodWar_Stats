export interface GetListRaceDto {
  getRacesDto: GetRaceDto[];
}

export interface GetRaceDto {
  raceID: string;
  name: string;
}

export interface ServiceResponse {
  data: any;
  messages: string;
  success: boolean;
}
