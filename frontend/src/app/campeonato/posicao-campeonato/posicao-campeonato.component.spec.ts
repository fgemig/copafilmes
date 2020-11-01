import { ResultadoCampeonato } from './../models/resultado-campeonato';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PosicaoCampeonatoComponent } from './posicao-campeonato.component';
import { Filme } from 'src/app/filmes/filme';

describe('PosicaoCampeonatoComponent', () => {
  let component: PosicaoCampeonatoComponent;
  let fixture: ComponentFixture<PosicaoCampeonatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PosicaoCampeonatoComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PosicaoCampeonatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve exibir o título do filme e a posição no campeonato', () => {

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

    component.resultadoCampeonato = resultadoCampeonato;
    fixture.detectChanges();

    const elementoClassificacao: HTMLElement = fixture.nativeElement;

    const campeaoDiv = elementoClassificacao.querySelectorAll('.classificacao-titulo')[0];
    expect(campeaoDiv.textContent).toContain(campeao.titulo);

    const viceCampeaoDiv = elementoClassificacao.querySelectorAll('.classificacao-titulo')[1];
    expect(viceCampeaoDiv.textContent).toContain(viceCampeao.titulo);

    expect(component).toBeTruthy();
  });
});
