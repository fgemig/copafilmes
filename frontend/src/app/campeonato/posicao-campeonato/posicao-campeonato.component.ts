import { Component, Input, OnInit } from '@angular/core';

import { ResultadoCampeonato } from '../models/resultado-campeonato';

@Component({
  selector: 'app-posicao-campeonato',
  templateUrl: './posicao-campeonato.component.html',
  styleUrls: ['./posicao-campeonato.component.css']
})
export class PosicaoCampeonatoComponent implements OnInit {

  @Input() resultadoCampeonato: ResultadoCampeonato;

  constructor() { }

  ngOnInit(): void {
    
  }

}
