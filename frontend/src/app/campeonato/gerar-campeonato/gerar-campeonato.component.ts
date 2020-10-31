import { Component, OnInit } from '@angular/core';

import { FilmesService } from './../../filmes/filmes.service';
import { CampeonatoService } from './../campeonato.service';

@Component({
  selector: 'app-gerar-campeonato',
  templateUrl: './gerar-campeonato.component.html',
  styleUrls: ['./gerar-campeonato.component.css']
})
export class GerarCampeonatoComponent implements OnInit {

  idsSelecionados: string[] = [];

  constructor(
    private campeonatoService: CampeonatoService,
    private filmesService: FilmesService) { }

  ngOnInit(): void {
    this.filmesService.obterFilmesSelecionados()
      .subscribe((idsSelecionados) => this.idsSelecionados = idsSelecionados);
  }

  gerarCampeonato(): void {

    this.campeonatoService.gerarCampeonato(this.idsSelecionados)
      .subscribe(res => console.log('ok'), err => console.log(err));
  }
}
