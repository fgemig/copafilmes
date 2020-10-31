import { Component, OnInit } from '@angular/core';

import { FilmesService } from './../../filmes/filmes.service';
import { CampeonatoService } from './../campeonato.service';
import { ResultadoCampeonato } from './../models/resultado-campeonato';

@Component({
  selector: 'app-resultado-campeonato',
  templateUrl: './resultado-campeonato.component.html',
  styleUrls: ['./resultado-campeonato.component.css']
})
export class ResultadoCampeonatoComponent implements OnInit {

  resultadoCampeonato: ResultadoCampeonato;

  constructor(
    private campeonatoService: CampeonatoService,
    private filmesService: FilmesService) { }

  ngOnInit(): void {

    const filmesIdsSelecionados = this.filmesService.ObterFilmesSelecionados();

    this.campeonatoService.gerarCampeonato(filmesIdsSelecionados)
        .subscribe((resultadoCampeonato) => {
          this.resultadoCampeonato = resultadoCampeonato;
          this.filmesService.removerFilmesSelecionados();
        });
  }
}
