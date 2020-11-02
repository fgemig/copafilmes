import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CabecalhoComponent } from './cabecalho.component';

describe('CabecalhoComponent', () => {
  let component: CabecalhoComponent;
  let fixture: ComponentFixture<CabecalhoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CabecalhoComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CabecalhoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve exibir o título e sub título', () => {

    const titulo = 'Campeonato de Filmes';
    const subtitulo = 'Fase de Seleção';
    const descricao = 'Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir';

    component.titulo = titulo;
    component.subTitulo = titulo;
    component.descricao = descricao;

    fixture.detectChanges();

    const elementoClassificacao: HTMLElement = fixture.nativeElement;

    const tituloDiv = elementoClassificacao.querySelector('.titulo');
    expect(tituloDiv.textContent).toContain(component.titulo);

    const subTituloDiv = elementoClassificacao.querySelector('.sub-titulo');
    expect(subTituloDiv.textContent).toContain(component.subTitulo);

    const descricaoDiv = elementoClassificacao.querySelector('.descricao');
    expect(descricaoDiv.textContent).toContain(component.descricao);

    expect(component).toBeTruthy();
  });
});
