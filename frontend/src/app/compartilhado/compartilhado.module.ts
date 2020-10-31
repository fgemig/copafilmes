import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { FocoBotaoDirective } from './diretivas/foco-botao/foco-botao.directive';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [
    CabecalhoComponent,
    FocoBotaoDirective,
    SpinnerComponent
  ],
  imports: [CommonModule],
  exports: [
    CabecalhoComponent,
    FocoBotaoDirective,
    SpinnerComponent]
})
export class CompartilhadoModule { }
