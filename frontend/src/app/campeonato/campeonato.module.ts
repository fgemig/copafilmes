import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CompartilhadoModule } from './../compartilhado/compartilhado.module';
import { BotaoDesabilitadoDirective } from './diretivas/botao-desabilitado/botao-desabilitado.directive';
import { GerarCampeonatoComponent } from './gerar-campeonato/gerar-campeonato.component';
import { PosicaoCampeonatoComponent } from './posicao-campeonato/posicao-campeonato.component';
import { ResultadoCampeonatoComponent } from './resultado-campeonato/resultado-campeonato.component';

@NgModule({
  declarations: [
    GerarCampeonatoComponent,
    ResultadoCampeonatoComponent,
    PosicaoCampeonatoComponent,
    BotaoDesabilitadoDirective
  ],
  imports: [
    CommonModule,
    CompartilhadoModule,
    RouterModule
  ],
  exports: [GerarCampeonatoComponent]
})
export class CampeonatoModule { }
