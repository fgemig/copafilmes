import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompartilhadoModule } from './compartilhado/compartilhado.module';
import { FilmesModule } from './filmes/filmes.module';
import { CampeonatoComponent } from './campeonato/campeonato.component';

@NgModule({
  declarations: [AppComponent, CampeonatoComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    CompartilhadoModule,
    FilmesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
