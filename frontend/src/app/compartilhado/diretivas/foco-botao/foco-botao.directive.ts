import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
    selector: '[appFocoBotao]'
})
export class FocoBotaoDirective {

    constructor(private el: ElementRef, private render: Renderer2) { }

    @HostListener('mouseover')
    focoOn(): void {
        this.render.addClass(this.el.nativeElement, 'foco-botao');
    }

    @HostListener('mouseleave')
    focoOff(): void {
        this.render.removeClass(this.el.nativeElement, 'foco-botao');
    }
}