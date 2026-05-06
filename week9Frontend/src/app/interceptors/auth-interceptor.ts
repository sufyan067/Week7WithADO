import { HttpInterceptorFn } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError, EMPTY } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  let token: string | null = null;
 //  SAFE CHECK (IMPORTANT)
  if (typeof window !== 'undefined') {
    token = localStorage.getItem('token');
  }
  let clonedReq = req;

  // Token attach
  if (token) {
    clonedReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  return next(clonedReq).pipe(
    catchError((err) => {

      //  Unauthorized
      if (err.status === 401) {
        alert('Session expired. Please login again.');

        localStorage.removeItem('token');

        //  IMPORTANT: stop further propagation
        return EMPTY;
      }

      //  Server error
      if (err.status === 500) {
        alert('Server error occurred. Please try again.');
      }

      //  Other errors -> pass to component
      return throwError(() => err);
    })
  );
};