import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { Router } from 'express';
import { NavbarComponent } from '../components/navbar/navbar.component';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {

}
