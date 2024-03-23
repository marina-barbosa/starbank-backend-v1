import { Routes } from '@angular/router';

import { HomeComponent } from './dashboard/home/home.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';
import { MyLottieComponent } from './components/my-lottie/my-lottie.component';
import { DashboardComponent } from './payments/dashboard/dashboard.component';
import { ComprovanteComponent } from './modal/comprovante/comprovante.component';
import { ConfirmacaoComponent } from './modal/confirmacao/confirmacao.component';
import { NegacaoComponent } from './modal/negacao/negacao.component';
import { PixComponent } from './payments/pix/pix.component';
import { TicketComponent } from './payments/ticket/ticket.component';
import { WithdrawalComponent } from './payments/withdrawal/withdrawal.component';

export const routes: Routes = [

  { path: '', component: LandingPageComponent },
  { path: 'land', component: LandingPageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'lottie', component: MyLottieComponent },
  { path: 'tour', component: ModalTourComponent },
  { path: 'home', component: HomeComponent },
  { path: 'dashboard-payment', component: DashboardComponent },
  { path: 'comprovante', component: ComprovanteComponent },
  { path: 'confirmacao', component: ConfirmacaoComponent },
  { path: 'negacao', component: NegacaoComponent },
  {path: 'pix', component: PixComponent},
  {path: 'ticket', component: TicketComponent},
  {path: 'withdrawal', component: WithdrawalComponent},
  { path: '**', redirectTo: 'land' },
];

