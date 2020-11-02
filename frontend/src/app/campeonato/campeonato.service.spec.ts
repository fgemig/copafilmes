import { CampeonatoService } from './campeonato.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { environment } from '../../environments/environment';
import { Filme } from '../filmes/filme';
import { ResultadoCampeonato } from './models/resultado-campeonato';

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

describe('CampeonatoService', () => {
    let service: CampeonatoService;
    let httpController: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [CampeonatoService],
            imports: [HttpClientTestingModule]
        });

        service = TestBed.inject(CampeonatoService);
        httpController = TestBed.inject(HttpTestingController);
    });

    it('deve retornar o resultado do campeonato', () => {

        const idsSelecionados: string[] = [];

        service.gerarCampeonato(idsSelecionados).subscribe(resultado => {
            expect(resultado).not.toBeNull();
            expect(resultado.campeao.titulo).toEqual('Filme 1');
            expect(resultado.viceCampeao.titulo).toEqual('Filme 2');
        });

        const req = httpController.expectOne(`${environment.urlApi}/api/partidas`);
        expect(req.request.method).toBe('POST');

        req.flush(resultadoCampeonato);
    });
});