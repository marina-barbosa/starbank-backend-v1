import { Routes } from '@angular/router';

import { HomeComponent } from './dashboard/home/home.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';
import { MyLottieComponent } from './components/my-lottie/my-lottie.component';
import { DashboardComponent } from './payments/dashboard/dashboard.component';
import { LayoutComponent } from './layout/layout.component';
import { NavbarComponent } from './components/navbar/navbar.component';

export const routes: Routes = [

  { path: '', component: LandingPageComponent },
  { path: 'land', component: LandingPageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'lottie', component: MyLottieComponent },
  { path: 'tour', component: ModalTourComponent },
  { path: 'home', component: HomeComponent },
  { path: 'dashboard-payment', component: DashboardComponent },
  { path: '**', redirectTo: 'land' },
  {
    path: '', component: LayoutComponent, children: [
      { path: 'navbar', component: NavbarComponent },
      // Outras rotas das páginas
    ]
  },
];

