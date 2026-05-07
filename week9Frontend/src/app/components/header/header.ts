import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  imports: [CommonModule],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
 constructor(private router: Router) {}

  logout() {
    localStorage.removeItem('token');
    alert('Logged out');
    this.router.navigate(['/']);
  }

  isLoggedIn() {
     if (typeof window === 'undefined') {
      return false; //  server side safe
    }
    return !!localStorage.getItem('token');
  }
}
