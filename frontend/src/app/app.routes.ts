import { Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';
import { MyLottieComponent } from './components/my-lottie/my-lottie.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ReceiptComponent } from './components/modal/receipt/receipt.component';
import { AcceptComponent } from './components/modal/accept/accept.component';
import { DeniedComponent } from './components/modal/denied/denied.component';
import { PixComponent } from './components/pix/pix.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';

export const routes: Routes = [

  { path: '', component: LandingPageComponent },
  { path: 'land', component: LandingPageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'lottie', component: MyLottieComponent },
  { path: 'tour', component: ModalTourComponent },
  { path: 'home', component: HomeComponent },
  { path: 'dashboard-payment', component: DashboardComponent },
  { path: 'receipt', component: ReceiptComponent },
  { path: 'accept', component: AcceptComponent },
  { path: 'denied', component: DeniedComponent },
  { path: 'pix', component: PixComponent},
  { path: 'ticket', component: TicketComponent},
  { path: 'withdrawal', component: WithdrawalComponent},
  { path: '**', redirectTo: 'land' },
];

