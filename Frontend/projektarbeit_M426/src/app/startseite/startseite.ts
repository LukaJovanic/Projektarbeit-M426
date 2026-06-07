import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {CommonModule, NgOptimizedImage} from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../../environment/environement';
import {RouterLink} from '@angular/router';

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
  selector: 'app-startseite',
  imports: [CommonModule, FormsModule, NgOptimizedImage, RouterLink],
  templateUrl: './startseite.html',
  styleUrl: './startseite.css',
  standalone: true,
})
export class Startseite implements OnInit {
  constructor(private http: HttpClient) {}

  searchTerm = '';
  isCreateModalOpen = false;
  isLoading = false;
  isSaving = false;
  errorMessage = '';

  apiUrl = apiUrl;

  vehicles: Vehicle[] = [];

  form: Vehicle = this.getEmptyForm();
  selectedImage: File | null = null;

  ngOnInit(): void {
    this.loadVehicles();
  }

  get filteredVehicles(): Vehicle[] {
    const term = this.searchTerm.trim().toLowerCase();

    if (!term) {
      return this.vehicles;
    }

    return this.vehicles.filter((vehicle) =>
      [
        vehicle.title,
        vehicle.description,
        vehicle.brand,
        vehicle.model,
        String(vehicle.price ?? ''),
        String(vehicle.year ?? ''),
        String(vehicle.kilometer ?? ''),
      ]
        .join(' ')
        .toLowerCase()
        .includes(term)
    );
  }

  openCreateModal(): void {
    this.form = this.getEmptyForm();
    this.selectedImage = null;
    this.errorMessage = '';
    this.isCreateModalOpen = true;
  }

  closeCreateModal(): void {
    this.isCreateModalOpen = false;
    this.errorMessage = '';
    this.selectedImage = null;
  }

  loadVehicles(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.http.get<Vehicle[]>(`${this.apiUrl}/getmotorrad`).subscribe({
      next: (data) => {
        this.vehicles = Array.isArray(data) ? data : [];
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Fehler beim Laden der Fahrzeuge:', error);
        this.errorMessage = 'Fahrzeuge konnten nicht geladen werden.';
        this.isLoading = false;
      },
    });
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files.length > 0) {
      this.selectedImage = input.files[0];
    }
  }

  saveVehicle(): void {
    if (!this.isFormValid()) {
      this.errorMessage = 'Bitte alle Pflichtfelder korrekt ausfüllen.';
      return;
    }

    this.isSaving = true;
    this.errorMessage = '';

    const formData = new FormData();

    formData.append('title', this.form.title.trim());
    formData.append('description', this.form.description.trim());
    formData.append('price', String(this.form.price));
    formData.append('brand', this.form.brand.trim());
    formData.append('model', this.form.model.trim());
    formData.append('kilometer', String(this.form.kilometer));

    if (this.form.year !== null) {
      formData.append('year', String(this.form.year));
    }

    if (this.selectedImage) {
      formData.append('image', this.selectedImage);
    }

    this.http.post<{ success: boolean }>(`${this.apiUrl}/create`, formData).subscribe({
      next: () => {
        this.isSaving = false;
        this.closeCreateModal();
        this.loadVehicles();
      },
      error: (error) => {
        console.error('Fehler beim Speichern:', error);
        this.errorMessage = 'Fahrzeug konnte nicht gespeichert werden.';
        this.isSaving = false;
      },
    });
  }

  trackByVehicle(index: number, vehicle: Vehicle): number | string {
    return vehicle.id ?? index;
  }

  private isFormValid(): boolean {
    return Boolean(
      this.form.title.trim() &&
      this.form.description.trim() &&
      this.form.price !== null &&
      this.form.brand.trim() &&
      this.form.model.trim() &&
      this.form.kilometer !== null
    );
  }
  getImageUrl(imageUrl: string | null | undefined): string {
    if (!imageUrl) return '';

    if (imageUrl.startsWith('http')) {
      return imageUrl;
    }

    return `${this.apiUrl}${imageUrl}`;
  }
  private getEmptyForm(): Vehicle {
    return {
      title: '',
      description: '',
      price: null,
      brand: '',
      model: '',
      kilometer: null,
      year: null,
      imageUrl: null,
    };
  }
}
