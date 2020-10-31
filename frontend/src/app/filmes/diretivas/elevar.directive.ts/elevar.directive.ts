import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appElevar]'
})
export class ElevarDirective {

  constructor(private el: ElementRef, private render: Renderer2) { }

  @HostListener('mouseover')
  elevarOn(): void {
    this.render.addClass(this.el.nativeElement, 'elevar');
  }

  @HostListener('mouseleave')
  elevarOff(): void {
    this.render.removeClass(this.el.nativeElement, 'elevar');
  }
}
