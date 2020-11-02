import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Filme } from 'src/app/filmes/filme';
import { FilmesService } from 'src/app/filmes/filmes.service';

import { CampeonatoService } from './../campeonato.service';
import { ResultadoCampeonato } from './../models/resultado-campeonato';
import { ResultadoCampeonatoComponent } from './resultado-campeonato.component';

const filmesSelecionados: string[] = ['00001','00002','00003'];

const campeao: Filme = {
  id: '00001',
  titulo: 'Filme 1',
  ano: 2020,
  nota: 8.5
};

const viceCampeao: Filme = {
  id: '00002',
  titulo: 'Filme 2',
  ano: 2018,
  nota: 5.2
};

const resultadoCampeonato: ResultadoCampeonato = {
  campeao,
  viceCampeao
};

describe('ResultadoCampeonatoComponent', () => {
  let component: ResultadoCampeonatoComponent;
  let fixture: ComponentFixture<ResultadoCampeonatoComponent>;
  let filmesService: FilmesService;
  let campeonatoService: CampeonatoService;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [ResultadoCampeonatoComponent],
      providers: [
        {
          provide: FilmesService, useValue: {
            ObterFilmesSelecionados: () => of(filmesSelecionados),
            removerFilmesSelecionados: () => {}
          }
        },
        {
          provide: CampeonatoService, useValue: {
            gerarCampeonato: () => of(resultadoCampeonato)
          }
        },
      ]
    })
      .compileComponents();
  });

  beforeEach(async () => {
    fixture = TestBed.createComponent(ResultadoCampeonatoComponent);
    component = fixture.componentInstance;
    filmesService = TestBed.inject(FilmesService);
    campeonatoService = TestBed.inject(CampeonatoService);
    fixture.detectChanges();
  });

  it('deve criar o componente com um cabeçalho', () => {

    fixture.detectChanges();

    const elemento = fixture.debugElement.nativeElement;
    expect(elemento.querySelector('app-cabecalho')).not.toBe(null);
  });

  it('deve criar o componente com uma posição no campeonato', () => {

    fixture.detectChanges();
    component.resultadoCampeonato = resultadoCampeonato;

    const elemento = fixture.debugElement.nativeElement;
    expect(elemento.querySelector('app-posicao-campeonato')).not.toBe(null);
  });
});
