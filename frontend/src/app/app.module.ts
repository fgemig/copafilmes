import { CommonModule } from '@angular/common';
import { CompartilhadoModule } from './compartilhado/compartilhado.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmesComponent } from './filmes/filmes.component';

@NgModule({
  declarations: [
    AppComponent,
    FilmesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    CompartilhadoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
