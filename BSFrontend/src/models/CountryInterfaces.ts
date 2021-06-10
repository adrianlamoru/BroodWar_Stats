export interface GetListCountryDto {
  getRacesDto: GetCountryDto[];
}

export interface GetCountryDto {
  countryID: string;
  name: string;
}
