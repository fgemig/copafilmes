import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { Filme } from '../filme';
import { FilmesService } from './../filmes.service';
import { FilmesListaComponent } from './filmes-lista.component';

const filmes: Filme[] = [
  {
    id: '00001',
    titulo: 'Filme 1',
    ano: 2020,
    nota: 5.5
  }
];

describe('FilmesListaComponent', () => {

  let component: FilmesListaComponent;
  let fixture: ComponentFixture<FilmesListaComponent>;
  let filmesService: FilmesService;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [FilmesListaComponent],
      providers: [
        {
          provide: FilmesService, useValue: {
            obterFilmes: () => of(filmes)
          }
        }
      ]
    })
      .compileComponents();
  });

  beforeEach(async () => {
    fixture = TestBed.createComponent(FilmesListaComponent);
    component = fixture.componentInstance;
    filmesService = TestBed.inject(FilmesService);
    fixture.detectChanges();
  });

  it('deve carregar uma lista de filmes', () => {
    spyOn(filmesService, 'obterFilmes')
    .and
    .callThrough();
    component.ngOnInit();
    fixture.detectChanges();
    expect(filmesService.obterFilmes);

    component.filmes$.subscribe(c => {
      expect(c.length).toEqual(1);
    });
  });
});
