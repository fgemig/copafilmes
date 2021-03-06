import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { CampeonatoModule } from './../campeonato/campeonato.module';
import { CompartilhadoModule } from './../compartilhado/compartilhado.module';
import { ElevarDirective } from './diretivas/elevar.directive.ts/elevar.directive';
import { FilmesContadorComponent } from './filmes-contador/filmes-contador.component';
import { FilmesListaComponent } from './filmes-lista/filmes-lista.component';
import { FilmesComponent } from './filmes.component';

@NgModule({
  declarations: [
    FilmesComponent,
    FilmesListaComponent,
    FilmesContadorComponent,
    ElevarDirective
  ],
  imports: [
    CommonModule,
    CompartilhadoModule,
    CampeonatoModule,
    HttpClientModule
  ],
  exports: [
    FilmesComponent,
    FilmesListaComponent
  ]
})
export class FilmesModule { }
