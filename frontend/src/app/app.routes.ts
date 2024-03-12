import { Routes } from '@angular/router';
import { HomeComponent } from './dashboard/home/home.component';

import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { MyLottieComponent } from './components/my-lottie/my-lottie.component';

export const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'land', component: LandingPageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'lottie', component: MyLottieComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: 'land' }
];

