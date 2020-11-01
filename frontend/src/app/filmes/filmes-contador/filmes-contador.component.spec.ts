import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { Filme } from '../filme';
import { FilmesService } from '../filmes.service';
import { FilmesContadorComponent } from './filmes-contador.component';

const filmes: Filme[] = [
  {
    id: '00001',
    titulo: 'Filme 1',
    ano: 2020,
    nota: 5.5
  }
];

describe('FilmesContadorComponent', () => {

  let component: FilmesContadorComponent;
  let fixture: ComponentFixture<FilmesContadorComponent>;
  let filmesService: FilmesService;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [FilmesContadorComponent],
      providers: [
        {
          provide: FilmesService, useValue: {
            obterTotalSelecionado: () => of(filmes)
          }
        }
      ]
    })
      .compileComponents();
  });

  beforeEach(async () => {
    fixture = TestBed.createComponent(FilmesContadorComponent);
    component = fixture.componentInstance;
    filmesService = TestBed.inject(FilmesService);
    fixture.detectChanges();
  });

  it('deve receber uma lista de filmes selecionados', () => {
    spyOn(filmesService, 'obterTotalSelecionado')
      .and
      .callThrough();
    component.ngOnInit();
    fixture.detectChanges();
    expect(filmesService.obterTotalSelecionado);
    expect(component.filmesSelecionados.length).toEqual(1);
  });

  it('deve mostrar a quantidade de filmes selecionados"', () => {
    const contadorElemento: HTMLElement = fixture.nativeElement;
    const totalSelecionadoDiv = contadorElemento.querySelector('.total-selecionado');
    expect(totalSelecionadoDiv.textContent).toContain('1 de 8 filmes');
  });
});
