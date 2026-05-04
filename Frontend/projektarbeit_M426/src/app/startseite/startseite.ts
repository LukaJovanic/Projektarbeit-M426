import {Component, OnInit} from '@angular/core';
import { FormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';
import {HttpClient} from '@angular/common/http';
import {apiUrl} from '../../environment/environement';
interface Vehicle {
  id?: number;
  marke: string;
  modell: string;
  preis: number | null;
  baujahr: number | null;
  kilometer: number | null;
  kraftstoff: string;
  ort: string;
  beschreibung: string;
}
@Component({
  selector: 'app-startseite',
  imports: [CommonModule, FormsModule],
  templateUrl: './startseite.html',
  styleUrl: './startseite.css',
  standalone: true,
})
export class Startseite implements OnInit {
  constructor(private http: HttpClient) { }

  searchTerm = '';
  isCreateModalOpen = false;
  isLoading = false;
  isSaving = false;
  errorMessage = '';

  private apiUrl = apiUrl;

  vehicles: Vehicle[] = [];

  form: Vehicle = this.getEmptyForm();

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
        vehicle.marke,
        vehicle.modell,
        vehicle.kraftstoff,
        vehicle.ort,
        vehicle.beschreibung,
        String(vehicle.baujahr ?? ''),
      ]
        .join(' ')
        .toLowerCase()
        .includes(term)
    );
  }

  openCreateModal(): void {
    this.form = this.getEmptyForm();
    this.errorMessage = '';
    this.isCreateModalOpen = true;
  }

  closeCreateModal(): void {
    this.isCreateModalOpen = false;
    this.errorMessage = '';
  }

  loadVehicles(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.http.get<Vehicle[]>(this.apiUrl).subscribe({
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

  saveVehicle(): void {
    if (!this.isFormValid()) {
      this.errorMessage = 'Bitte alle Pflichtfelder korrekt ausfüllen.';
      return;
    }

    this.isSaving = true;
    this.errorMessage = '';

    const payload: Vehicle = {
      marke: this.form.marke.trim(),
      modell: this.form.modell.trim(),
      preis: Number(this.form.preis),
      baujahr: Number(this.form.baujahr),
      kilometer: Number(this.form.kilometer),
      kraftstoff: this.form.kraftstoff,
      ort: this.form.ort.trim(),
      beschreibung: this.form.beschreibung.trim(),
    };

    this.http.post<Vehicle>(this.apiUrl, payload).subscribe({
      next: (createdVehicle) => {
        this.vehicles = [createdVehicle, ...this.vehicles];
        this.isSaving = false;
        this.closeCreateModal();
      },
      error: (error) => {
        console.error('Fehler beim Speichern:', error);
        this.errorMessage = 'Fahrzeug konnte nicht gespeichert werden.';
        this.isSaving = false;
      },
    });
  }

  removeVehicle(vehicleId: number | undefined): void {
    if (!vehicleId) {
      return;
    }

    this.http.delete<void>(`${this.apiUrl}/${vehicleId}`).subscribe({
      next: () => {
        this.vehicles = this.vehicles.filter((vehicle) => vehicle.id !== vehicleId);
      },
      error: (error) => {
        console.error('Fehler beim Löschen:', error);
        this.errorMessage = 'Fahrzeug konnte nicht gelöscht werden.';
      },
    });
  }

  trackByVehicle(index: number, vehicle: Vehicle): number | string {
    return vehicle.id ?? index;
  }

  private isFormValid(): boolean {
    return Boolean(
      this.form.marke.trim() &&
      this.form.modell.trim() &&
      this.form.preis !== null &&
      this.form.baujahr !== null &&
      this.form.kilometer !== null &&
      this.form.kraftstoff &&
      this.form.ort.trim()
    );
  }

  private getEmptyForm(): Vehicle {
    return {
      marke: '',
      modell: '',
      preis: null,
      baujahr: null,
      kilometer: null,
      kraftstoff: '',
      ort: '',
      beschreibung: '',
    };
  }
}
