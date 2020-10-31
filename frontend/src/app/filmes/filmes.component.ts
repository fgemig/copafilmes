import { Component, OnInit } from '@angular/core';
import { Filme } from './filme';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {

  filmesSelecionados: Filme[];

  constructor() { }

  ngOnInit(): void {
  }

 

}
