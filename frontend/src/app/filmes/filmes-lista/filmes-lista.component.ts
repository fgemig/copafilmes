import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { Filme } from '../filme';
import { FilmesService } from './../filmes.service';

@Component({
  selector: 'app-files-lista',
  templateUrl: './filmes-lista.component.html',
  styleUrls: ['./filmes-lista.component.css']
})
export class FilmesListaComponent implements OnInit {

  filmes$: Observable<Filme[]>;

  constructor(private filmeService: FilmesService) { }

  ngOnInit(): void {
    this.filmes$ = this.filmeService.obterFilmes();
  }

  selecionarFilme(filme: Filme, $event): void {
    if ($event.target.checked) {
      this.filmeService.adicionarFilme(filme.id);
    } else {
      this.filmeService.removerFilme(filme.id);
    }
  }
}
