import { Component, Input } from '@angular/core';

import { ResultadoCampeonato } from '../models/resultado-campeonato';

@Component({
  selector: 'app-posicao-campeonato',
  templateUrl: './posicao-campeonato.component.html',
  styleUrls: ['./posicao-campeonato.component.css']
})
export class PosicaoCampeonatoComponent  {

  @Input() resultadoCampeonato: ResultadoCampeonato;
}
