import { TestBed } from '@angular/core/testing';

import { FilmesService } from './filmes.service';

describe('FilmesListaService', () => {
  let service: FilmesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FilmesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
