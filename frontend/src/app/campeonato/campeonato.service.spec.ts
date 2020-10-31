import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { CampeonatoService } from './campeonato.service';

describe('CampeonatoService', () => {
  let service: CampeonatoService;

  beforeEach(() => {
    TestBed.configureTestingModule(
      {
        imports: [HttpClientModule],
        providers: [HttpClient]
      });
    service = TestBed.inject(CampeonatoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
