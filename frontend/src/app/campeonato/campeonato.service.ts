import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { ResultadoCampeonato } from './models/resultado-campeonato';

@Injectable({
  providedIn: 'root'
})
export class CampeonatoService {

  constructor(private httpClient: HttpClient) { }

  gerarCampeonato(idsSelecionados: string[]): Observable<ResultadoCampeonato> {
    return this.httpClient
      .post<ResultadoCampeonato>(`${environment.urlApi}/api/partidas`, idsSelecionados );
  }
}
