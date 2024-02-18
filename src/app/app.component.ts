import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from "./dashboard/home/home.component";
import { FooterComponent } from "./components/footer/footer.component";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, FormsModule, RouterOutlet, HomeComponent, FooterComponent]
})
export class AppComponent {
  title = 'StarPay';
}
