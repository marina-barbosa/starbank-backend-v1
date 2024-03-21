import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

import { HomeComponent } from "./dashboard/home/home.component";
import { FooterComponent } from "./components/footer/footer.component";
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { ModalTourComponent } from './components/modal-tour/modal-tour.component';
import { NavbarComponent } from './components/navbar/navbar.component';


@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',

  imports: [CommonModule, FormsModule, RouterOutlet, HomeComponent, FooterComponent, LandingPageComponent, ModalTourComponent, NavbarComponent,],

})
export class AppComponent {
  title = 'StarPay';
}
