import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';

@NgModule({
  declarations: [CabecalhoComponent],
  imports: [CommonModule],
  exports: [CabecalhoComponent]
})
export class CompartilhadoModule { }
