import { Router } from '@angular/router';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(catchError(response => {

      if (response instanceof HttpErrorResponse) {

        if (response.status !== 200) {
          this.router.navigate(['erro']);
        }
      }

      return next.handle(response);
    }));
  }
}
