import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {RaceService} from './services/race.service'
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PlayerformComponent } from './components/playerform/playerform.component';
import { RaceselectorComponent } from './components/shared/raceselector/raceselector.component';
import { CountryselectorComponent } from './components/shared/countryselector/countryselector.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    
    PlayerformComponent,
    
    RaceselectorComponent,
    
    CountryselectorComponent,
    
    NavbarComponent,
    
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [RaceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
