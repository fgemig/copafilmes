import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CampeonatoGuard } from './campeonato/campeonato.guard';
import { ResultadoCampeonatoComponent } from './campeonato/resultado-campeonato/resultado-campeonato.component';
import { FilmesComponent } from './filmes/filmes.component';

const routes: Routes = [
  {
    path: '',
    component: FilmesComponent
  },
  {
    path: 'resultado',
    component: ResultadoCampeonatoComponent,
    canActivate: [CampeonatoGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
