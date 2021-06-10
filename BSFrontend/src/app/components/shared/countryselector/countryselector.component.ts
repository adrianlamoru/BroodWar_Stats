import { Component, EventEmitter, Input, Output } from '@angular/core';
import { GetCountryDto } from 'src/models/CountryInterfaces';
import { CountryService } from '../../../services/country.service';

@Component({
  selector: 'app-countryselector',
  templateUrl: './countryselector.component.html',
  styleUrls: ['./countryselector.component.css'],
})
export class CountryselectorComponent {
  _getListCountryDto: GetCountryDto[] = new Array<GetCountryDto>();
  countryID: number = 0;

  constructor(private _countryService: CountryService) {
    this.ReturnCountry();
  }

  @Input() selectedValue:number;
  @Output() onCountryID: EventEmitter<number> = new EventEmitter();

  ReturnCountry() {
    this._countryService.sendGetRequest().subscribe((res) => {
      this._getListCountryDto = res.data['countriesDto'];
    });
  }

  returnCountryID() {
    this.onCountryID.emit(this.countryID);
  }
}
