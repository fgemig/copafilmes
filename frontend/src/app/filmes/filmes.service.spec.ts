import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { environment } from '../../environments/environment';
import { Filme } from './filme';
import { FilmesService } from './filmes.service';

const filmes: Filme[] = [
    {
        id: '00001',
        titulo: 'Filme 1',
        ano: 2020,
        nota: 5.5
    },
    {
        id: '00002',
        titulo: 'Filme 2',
        ano: 2018,
        nota: 8.2
    }
];

describe('FilmesService', () => {
    let service: FilmesService;
    let httpController: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [FilmesService],
            imports: [HttpClientTestingModule]
        });

        service = TestBed.inject(FilmesService);
        httpController = TestBed.inject(HttpTestingController);
    });

    it('deve retornar uma lista de filmes', () => {

        service.obterFilmes().subscribe(response => {
            expect(response.length).toEqual(2);
            expect(response[0].titulo).toEqual('Filme 1');
            expect(response[1].titulo).toEqual('Filme 2');
        });

        const req = httpController.expectOne(`${environment.urlApi}/api/filmes`);
        expect(req.request.method).toBe('GET');

        req.flush(filmes);

    });
});