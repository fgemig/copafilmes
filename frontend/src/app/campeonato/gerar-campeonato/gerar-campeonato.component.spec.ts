import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GerarCampeonatoComponent } from './gerar-campeonato.component';

describe('GerarCampeonatoComponent', () => {
  let component: GerarCampeonatoComponent;
  let fixture: ComponentFixture<GerarCampeonatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GerarCampeonatoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GerarCampeonatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it(`deve exibir um botão 'Gerar meu Campeonato'`, () => {

    fixture.detectChanges();

    const elemento: HTMLElement = fixture.nativeElement;

    const botaoGerarMeuCampeonato = elemento.querySelector('button');

    expect(botaoGerarMeuCampeonato).toBeTruthy();
    expect(botaoGerarMeuCampeonato.textContent).toContain('Gerar meu Campeonato');
  });
});
