import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CreatePatientModel } from '../models/patient.model';
import { UpdatePatient } from '../models/patient.model';
@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPatients() {
    return this.http.get(`${this.baseUrl}/patient`);
  }

  getPatientById(id: number) {
    return this.http.get(`${this.baseUrl}/patient/${id}`);
  }
  CreatePatient(payload: CreatePatientModel) {
    return this.http.post(`${this.baseUrl}/patient`, payload);
  }

  updatePatient(payload: UpdatePatient) {
    return this.http.put(`${this.baseUrl}/patient`, payload);
  }
  deletePatient(id: number) {
    return this.http.delete(`${this.baseUrl}/patient/${id}`);
  }
}