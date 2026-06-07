import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgClass } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../../environment/environement';
import { Router } from '@angular/router';

type StrengthLabel = 'Weak' | 'Okay' | 'Strong';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  imports: [
    FormsModule,
    NgClass
  ]
})
export class RegisterComponent {
  username = '';
  email = '';
  password = '';
  confirmPassword = '';
  acceptedTerms = false;

  meetsLen = false;
  meetsCase = false;
  meetsNumber = false;
  meetsSpecial = false;

  strengthScore = 0;
  strengthLabel: StrengthLabel = 'Weak';
  apiUrl = apiUrl;

  constructor(private http: HttpClient, private router: Router) {
  }

  get passwordsMatch(): boolean {
    return !!this.password && this.password === this.confirmPassword;
  }

  onPasswordChange(next: string): void {
    this.password = next ?? '';
    this.recomputePasswordMetrics();
  }

  onSubmit(): void {
    if (!this.username.trim()) return;
    if (!this.email.trim()) return;
    if (!this.acceptedTerms) return;
    if (!this.passwordsMatch) return;
    if (this.strengthScore < 40) return;

    const payload = {
      username: this.username.trim(),
      email: this.email.trim(),
      password: this.password
    };

    this.http.post<{ success: boolean; message: string }>(`${this.apiUrl}/registrieren`, payload).subscribe({
      next: response => {
        if (response.success) {
          this.router.navigate(['login']);
        }
      },
      error: error => {
        console.error('Register failed', error);
      }
    });

    console.log('Register submit', payload);
  }

  private recomputePasswordMetrics(): void {
    const p = this.password || '';

    this.meetsLen = p.length >= 8;
    this.meetsCase = /[a-z]/.test(p) && /[A-Z]/.test(p);
    this.meetsNumber = /\d/.test(p);
    this.meetsSpecial = /[^A-Za-z0-9]/.test(p);

    const lengthPoints = Math.min(40, p.length * 4);

    const criteriaPoints =
      (this.meetsCase ? 15 : 0) +
      (this.meetsNumber ? 15 : 0) +
      (this.meetsSpecial ? 15 : 0);

    const uniqueCount = new Set(p.split('')).size;
    const varietyPoints = Math.min(15, uniqueCount * 1.5);

    const penalties = this.computePenalties(p);

    const raw = lengthPoints + criteriaPoints + varietyPoints - penalties;
    this.strengthScore = this.clamp(Math.round(raw), 0, 100);

    this.strengthLabel =
      this.strengthScore > 60 ? 'Strong' : this.strengthScore > 25 ? 'Okay' : 'Weak';
  }

  private computePenalties(p: string): number {
    if (!p) return 0;

    let penalty = 0;

    if (/^(.)\1+$/.test(p)) penalty += 30;

    const lower = p.toLowerCase();
    const sequences = ['abcdefghijklmnopqrstuvwxyz', '0123456789'];

    for (const seq of sequences) {
      if (this.containsSubstringOf(seq, lower, 4)) penalty += 15;

      const rev = seq.split('').reverse().join('');
      if (this.containsSubstringOf(rev, lower, 4)) penalty += 15;
    }

    const maxRepeatRun = this.maxRunLength(p);
    if (maxRepeatRun >= 4) penalty += Math.min(20, (maxRepeatRun - 3) * 5);

    const emailLower = this.email.trim().toLowerCase();
    if (emailLower && emailLower.length >= 3 && lower.includes(emailLower)) penalty += 15;

    const usernameLower = this.username.trim().toLowerCase();
    if (usernameLower && usernameLower.length >= 3 && lower.includes(usernameLower)) penalty += 15;

    if (p.length < 6) penalty += 20;

    return penalty;
  }

  private containsSubstringOf(sequence: string, target: string, minLen: number): boolean {
    for (let i = 0; i <= sequence.length - minLen; i++) {
      const chunk = sequence.slice(i, i + minLen);
      if (target.includes(chunk)) return true;
    }

    return false;
  }

  private maxRunLength(s: string): number {
    let best = 1;
    let run = 1;

    for (let i = 1; i < s.length; i++) {
      if (s[i] === s[i - 1]) run++;
      else run = 1;

      if (run > best) best = run;
    }

    return best;
  }

  private clamp(n: number, min: number, max: number): number {
    return Math.max(min, Math.min(max, n));
  }
}
