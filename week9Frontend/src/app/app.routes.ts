import { Routes } from '@angular/router';
import { authGuard } from './guards/auth-guard';
import { Login } from './components/login/login';
import { Patient } from './components/patient/patient';
export const routes: Routes = [
     {path:'', component: Login},
    {path:'patients', component: Patient, canActivate:[authGuard]}  // protect route 
];
