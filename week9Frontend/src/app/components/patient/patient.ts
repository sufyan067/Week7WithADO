import { Component } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { CommonModule } from '@angular/common';
import { CreatePatientModel } from '../../models/patient.model';
import { UpdatePatient } from '../../models/patient.model';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
@Component({
  selector: 'app-patient',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './patient.html',
  styleUrl: './patient.css',
})
export class Patient {
  patients: any[] = [];
  form;
  updateForm;
  constructor(private fb: FormBuilder, private patientService: PatientService) {
    this.form = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: [''],
      City: [''],
      PhoneNumber: [''],
      DateOfBirth: ['']
    });
    this.updateForm = this.fb.group({
      patientId: ['', Validators.required],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: [''],
      City: [''],
      PhoneNumber: [''],
      DateOfBirth: ['']
    });
  }

  createPatient() {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const formValue = this.form.getRawValue();

    const payload: CreatePatientModel = {
      FirstName: formValue.FirstName!,
      LastName: formValue.LastName!,
      Email: formValue.Email || null,
      City: formValue.City || null,
      PhoneNumber: formValue.PhoneNumber || null,
      DateOfBirth: formValue.DateOfBirth
        ? new Date(formValue.DateOfBirth).toISOString()
        : null
    };

    console.log('Sending:', payload);

    this.patientService.CreatePatient(payload).subscribe({
      next: () => {
        console.log('Created ');
        alert('Patient Created ');
        this.form.reset();
      },
      error: (err) => {
        console.log(err.error);
      }
    });
  }
  updatePatient() {

    if (this.updateForm.invalid) {
      this.updateForm.markAllAsTouched();
      return;
    }

    const formValue = this.updateForm.value;

    const payload: UpdatePatient = {
      patientId: Number(formValue.patientId), // important to convert to number
      FirstName: formValue.FirstName!,
      LastName: formValue.LastName!,
      Email: formValue.Email || null,
      City: formValue.City || null,
      PhoneNumber: formValue.PhoneNumber || null,
      DateOfBirth: formValue.DateOfBirth
        ? new Date(formValue.DateOfBirth).toISOString()
        : null
    };

    console.log('Updating:', payload);

    this.patientService.updatePatient(payload).subscribe({
      next: () => {
        alert('Patient Updated');
        this.updateForm.reset();
      },
      error: (err) => {
        console.log(err.error);
      }
    });
  }
  getPatients() {
    this.patientService.getPatients().subscribe({
      next: (res) => {
        console.log('All Patients:', res);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  getPatientById() {
    const id = Number(this.updateForm.value.patientId);

    if (!id) {
      alert('Enter valid Patient ID');
      return;
    }
    this.patientService.getPatientById(id).subscribe({
      next: (res) => {
        console.log('Patient By ID:', res);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
  deletePatient() {

    const id = Number(this.updateForm.value.patientId);

    if (!id) {
      alert('Enter valid Patient ID');
      return;
    }

    if (!confirm('Are you sure you want to delete this patient?')) {
      return;
    }

    this.patientService.deletePatient(id).subscribe({
      next: () => {
        alert('Patient Deleted');
        this.updateForm.reset();
      },
      error: (err) => {
        console.log(err.error);
      }
    });
  }
}























// const payload: CreatePatientModel = {
//       FirstName: this.form.value.FirstName!,
//       LastName: this.form.value.LastName!,
//       Email: this.form.value.Email || null,
//       City: this.form.value.City || null,
//       PhoneNumber: this.form.value.PhoneNumber || null,
//       DateOfBirth: this.form.value.DateOfBirth
//         ? new Date(this.form.value.DateOfBirth).toISOString()
//         : null
//     };