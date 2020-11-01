import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CampeonatoGuard } from './campeonato/campeonato.guard';
import { ResultadoCampeonatoComponent } from './campeonato/resultado-campeonato/resultado-campeonato.component';
import { NaoEncontradoComponent } from './compartilhado/nao-encontrado/nao-encontrado.component';
import { ErrosComponent } from './erros/erros.component';
import { FilmesComponent } from './filmes/filmes.component';


const routes: Routes = [
  {
    path: '',
    component: FilmesComponent,
    data: {
      titulo: 'Copa Filmes'
    }
  },
  {
    path: 'resultado',
    component: ResultadoCampeonatoComponent,
    canActivate: [CampeonatoGuard],
    data: {
      titulo: 'Copa Filmes - Resultado'
    }
  },
  {
    path: 'erro',
    component: ErrosComponent,
    data: {
      title: 'Erro'
    }
  },
  {
    path: 'nao-encontrado',
    component: NaoEncontradoComponent,
    data: {
      title: 'Página não encontrada'
    }
  },
  {
    path: '**',
    redirectTo: 'nao-encontrado'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
