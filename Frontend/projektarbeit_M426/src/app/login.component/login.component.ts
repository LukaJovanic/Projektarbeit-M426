import { Component } from '@angular/core';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [
    FormsModule
  ],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = '';
  password = '';
  rememberMe = false;
  errorMessage = '';

  onSubmit(): void {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please fill in all required fields.';
      return;
    }

    this.errorMessage = '';

    console.log({
      username: this.username,
      password: this.password,
      rememberMe: this.rememberMe
    });
  }
}
