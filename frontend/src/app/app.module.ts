import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompartilhadoModule } from './compartilhado/compartilhado.module';
import { FilmesModule } from './filmes/filmes.module';

@NgModule({
  declarations: [AppComponent],
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
