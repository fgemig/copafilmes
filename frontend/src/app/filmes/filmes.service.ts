import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Filme } from './filme';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FilmesService {

  private filmesSelecionados: BehaviorSubject<string[]>;
  private filmesSelecionadosArr: string[] = [];

  constructor(private http: HttpClient) {
    this.filmesSelecionados = new BehaviorSubject<string[]>([]);
  }

  obterFilmes(): Observable<Filme[]> {
    return this.http.get<Filme[]>(`${environment.urlApi}/api/filmes`);
  }

  obterTotalSelecionado(): Observable<string[]> {
    return this.filmesSelecionados.asObservable();
  }

  ObterFilmesSelecionados(): string[] {
    return this.filmesSelecionadosArr;
  }

  adicionarFilme(filmeId: string): void {
    this.filmesSelecionadosArr.push(filmeId);
    this.filmesSelecionados.next(this.filmesSelecionadosArr);
  }

  removerFilme(filmeId: string): void {

    const indice = this.filmesSelecionadosArr
      .findIndex(filme => filme === filmeId);

    if (indice >= 0) {
      this.filmesSelecionadosArr.splice(indice, 1);
      this.filmesSelecionados.next(this.filmesSelecionadosArr);
    }
  }

  removerFilmesSelecionados(): void {
    this.filmesSelecionadosArr = [];
    this.filmesSelecionados.next(this.filmesSelecionadosArr);
  }
}
