import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

import { HomeComponent } from "./pages/home/home.component";
import { FooterComponent } from "./components/footer/footer.component";
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { WithdrawalComponent } from './components/withdrawal/withdrawal.component';
import { DashboardComponent } from "./components/dashboard/dashboard.component";


@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [CommonModule, FormsModule, RouterOutlet, HomeComponent, FooterComponent, LandingPageComponent, ModalTourComponent, NavbarComponent, WithdrawalComponent, DashboardComponent]
})
export class AppComponent {
  title = 'StarPay';
}
