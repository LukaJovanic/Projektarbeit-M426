import {Component, inject} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {apiUrl} from '../../environment/environement';
import {Router} from '@angular/router';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [
    FormsModule, CommonModule, RouterLink
  ],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = '';
  password = '';
  rememberMe = false;
  errorMessage = '';
  apiUrl = apiUrl ;
  http = inject(HttpClient);
  router = inject(Router);
  onSubmit(): void {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please fill in all required fields.';
      return;
    }

    const request = {username: this.username, password: this.password};
    this.http.post<{success: boolean, message: string}>(`${this.apiUrl}/anmelden`, request).subscribe({
      next: response => {
        console.log(response);
        if (response.success) {
          this.errorMessage = '';
          this.router.navigate(['startseite'])
        } else {
          this.errorMessage = response.message;
        }
      }
    })


    console.log({
      username: this.username,
      password: this.password,
      rememberMe: this.rememberMe
    });
  }
}
