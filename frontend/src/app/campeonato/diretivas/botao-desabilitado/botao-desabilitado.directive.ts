import { Directive, ElementRef, OnInit, Renderer2 } from '@angular/core';

import { FilmesService } from './../../../filmes/filmes.service';

@Directive({
    selector: '[appBotaoDesabilitado]'
})
export class BotaoDesabilitadoDirective implements OnInit {

    constructor(
        private filmesService: FilmesService,
        private element: ElementRef,
        private renderer: Renderer2) { }

    ngOnInit(): void {

        this.filmesService.obterTotalSelecionado()
            .subscribe(totalSelecionado => {
                if (totalSelecionado.length === 8) {
                    this.renderer.setProperty(this.element.nativeElement, 'disabled', false);
                } else {
                    this.renderer.setProperty(this.element.nativeElement, 'disabled', true);
                }
            });
    }
}
