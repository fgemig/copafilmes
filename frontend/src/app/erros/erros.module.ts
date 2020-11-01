import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { CompartilhadoModule } from './../compartilhado/compartilhado.module';
import { ErrosComponent } from './erros.component';
import { RequestInterceptor } from './request.interceptor';

@NgModule({
  declarations: [ErrosComponent],
  imports: [
    CommonModule,
    CompartilhadoModule,
    RouterModule
  ],
  exports: [ErrosComponent],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: RequestInterceptor,
    multi: true
  }]
})
export class ErrosModule { }
