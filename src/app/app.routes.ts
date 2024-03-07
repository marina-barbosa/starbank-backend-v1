import { Routes } from '@angular/router';
import { HomeComponent } from './dashboard/home/home.component';

import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';

export const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'land', component: LandingPageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'tour', component: ModalTourComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'land' }
];

