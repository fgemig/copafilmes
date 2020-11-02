import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrosComponent } from './erros.component';

describe('ErrosComponent', () => {
  let component: ErrosComponent;
  let fixture: ComponentFixture<ErrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ErrosComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ErrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve criar o componente com um cabeçalho', () => {

    fixture.detectChanges();

    const elemento = fixture.debugElement.nativeElement;
    expect(elemento.querySelector('app-cabecalho')).not.toBe(null);
  });

  it('deve criar o componente com um botão voltar', () => {

    fixture.detectChanges();

    const elemento: HTMLElement = fixture.nativeElement;

    const botaoVoltar = elemento.querySelector('button');

    expect(botaoVoltar).toBeTruthy();
    expect(botaoVoltar.textContent).toContain('Voltar');
  });
});
