import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {RaceService} from './services/race.service'
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PlayerformComponent } from './components/playerform/playerform.component';
import { RaceselectorComponent } from './components/shared/raceselector/raceselector.component';
import { CountryselectorComponent } from './components/shared/countryselector/countryselector.component';

@NgModule({
  declarations: [
    AppComponent,
    
    PlayerformComponent,
    
    RaceselectorComponent,
    
    CountryselectorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [RaceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
