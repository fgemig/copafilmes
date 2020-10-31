import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { FocoBotaoDirective } from './diretivas/foco-botao/foco-botao.directive';

@NgModule({
  declarations: [CabecalhoComponent, FocoBotaoDirective],
  imports: [CommonModule],
  exports: [CabecalhoComponent, FocoBotaoDirective]
})
export class CompartilhadoModule { }
