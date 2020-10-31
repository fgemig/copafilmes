import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesContadorComponent } from './filmes-contador.component';

describe('FilmesContadorComponent', () => {
  let component: FilmesContadorComponent;
  let fixture: ComponentFixture<FilmesContadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilmesContadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmesContadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
