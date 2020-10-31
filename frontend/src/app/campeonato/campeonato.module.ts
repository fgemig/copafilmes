import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { GerarCampeonatoComponent } from './gerar-campeonato/gerar-campeonato.component';

@NgModule({
  declarations: [GerarCampeonatoComponent],
  imports: [CommonModule],
  exports: [GerarCampeonatoComponent]
})
export class CampeonatoModule { }
