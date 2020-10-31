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

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
