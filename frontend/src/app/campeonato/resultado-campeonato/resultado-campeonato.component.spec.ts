import { HttpClient, HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultadoCampeonatoComponent } from './resultado-campeonato.component';

describe('ResultadoCampeonatoComponent', () => {
  let component: ResultadoCampeonatoComponent;
  let fixture: ComponentFixture<ResultadoCampeonatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResultadoCampeonatoComponent ],
      imports : [HttpClientModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResultadoCampeonatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
