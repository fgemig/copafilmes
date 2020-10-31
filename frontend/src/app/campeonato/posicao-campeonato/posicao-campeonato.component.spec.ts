import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PosicaoCampeonatoComponent } from './posicao-campeonato.component';

describe('PosicaoCampeonatoComponent', () => {
  let component: PosicaoCampeonatoComponent;
  let fixture: ComponentFixture<PosicaoCampeonatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PosicaoCampeonatoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PosicaoCampeonatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
