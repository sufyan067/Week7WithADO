import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  form;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.form = this.fb.group({
      username: [''],
      password: ['']
    });
  }

  login() {
    this.authService.login(this.form.value).subscribe({
      next: (res: any) => {
        console.log(res);
        localStorage.setItem('token', res.token);
        alert('Login Success');
        this.router.navigate(['/patients']);

      },
      error: () => {
        alert('Login failed');
      }
    });
  }
  
  
}