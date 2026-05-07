export interface CreatePatientModel {
  FirstName: string;
  LastName: string;
  Email?: string | null;
  City?: string | null;
  PhoneNumber?: string | null;
  DateOfBirth?: string | null;
}
export interface UpdatePatient extends CreatePatientModel {
  patientId: number;
}