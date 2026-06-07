import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { apiUrl } from '../../environment/environement';

interface Vehicle {
  id?: number;
  title: string;
  description: string;
  price: number | null;
  brand: string;
  model: string;
  kilometer: number | null;
  year: number | null;
  imageUrl?: string | null;
}

@Component({
  selector: 'app-motorrad-uebersicht',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './motorrad-uebersicht.component.html',
  styleUrl: './motorrad-uebersicht.component.css',
})
export class MotorradUebersichtComponent implements OnInit {
  constructor(private router: Router) {}

  apiUrl = apiUrl;

  vehicle: Vehicle | null = null;
  errorMessage = '';

  ngOnInit(): void {
    this.vehicle = history.state.vehicle ?? null;

    if (!this.vehicle) {
      this.errorMessage = 'Kein Motorrad übergeben.';
    }
  }

  getImageUrl(imageUrl: string | null | undefined): string {
    if (!imageUrl) {
      return '';
    }

    if (imageUrl.startsWith('http')) {
      return imageUrl;
    }

    return `${this.apiUrl}${imageUrl}`;
  }

  goBack(): void {
    this.router.navigate(['/startseite']);
  }
}
