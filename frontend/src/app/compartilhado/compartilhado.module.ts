import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { FocoBotaoDirective } from './diretivas/foco-botao/foco-botao.directive';
import { NaoEncontradoComponent } from './nao-encontrado/nao-encontrado.component';
import { RodapeComponent } from './rodape/rodape.component';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [
    CabecalhoComponent,
    FocoBotaoDirective,
    SpinnerComponent,
    NaoEncontradoComponent,
    RodapeComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    CabecalhoComponent,
    FocoBotaoDirective,
    SpinnerComponent,
    NaoEncontradoComponent,
    RodapeComponent
  ]
})
export class CompartilhadoModule { }
