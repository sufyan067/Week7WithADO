import { CanActivateFn } from '@angular/router';
import { Inject } from '@angular/core';
import { Router } from '@angular/router';
export const authGuard: CanActivateFn = (route, state) => {
 const router = Inject(Router);
  const token = localStorage.getItem('token');

  if (token) {
    return true; //  allow access
  }

  //  not logged in -> redirect
  router.navigate(['/']);

  return false;
  };
