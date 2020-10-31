import { Component, Input, OnInit } from '@angular/core';
import { Filme } from '../filme';
import { FilmesService } from '../filmes.service';

@Component({
  selector: 'app-filmes-contador',
  templateUrl: './filmes-contador.component.html',
  styleUrls: ['./filmes-contador.component.css']
})
export class FilmesContadorComponent implements OnInit {

  filmesSelecionados: string[];

  constructor(private filmesService: FilmesService) { }

  ngOnInit(): void {
    this.filmesService.obterFilmesSelecionados()
      .subscribe(selecionados => this.filmesSelecionados = selecionados);
  }

}
