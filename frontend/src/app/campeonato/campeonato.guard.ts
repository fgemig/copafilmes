import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

import { FilmesService } from './../filmes/filmes.service';

@Injectable({
    providedIn: 'root'
})
export class CampeonatoGuard implements CanActivate {

    constructor(private filmesService: FilmesService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

        const total = this.filmesService.ObterFilmesSelecionados();

        if (total.length !== 8) {
            this.router.navigate(['']);
            return false;
        }

        return true;
    }
}
