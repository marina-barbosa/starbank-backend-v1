import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FooterComponent } from "../../components/footer/footer.component";
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CentralComponent } from '../central/central.component';
import { TransacoesComponent } from '../transacoes/transacoes.component';

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  imports: [CommonModule, FooterComponent, FormsModule, RouterOutlet, CentralComponent, TransacoesComponent, RouterLink]
})
export class HomeComponent {

  user: {
    name: string,
    momento: Date,
    avatar: string
  };

  cumprimento: string;

  menuIconChecked = false;

  selectedComponent: string = 'central';



  constructor() {

    this.user = {
      name: 'Admin',
      momento: new Date(),
      avatar: '../../../assets/perfil.png'
    };

    const horaAtual = this.user.momento.getHours();
    if (horaAtual >= 5 && horaAtual < 12) {
      this.cumprimento = 'Bom dia';
    } else if (horaAtual >= 12 && horaAtual < 18) {
      this.cumprimento = 'Boa tarde';
    } else {
      this.cumprimento = 'Boa noite';
    }

  }

  chooseComponent($event: any) {
    if ($event.srcElement.id === 'central') {
      this.selectedComponent = 'central';
    } else if ($event.srcElement.id === 'transacoes') {
      this.selectedComponent = 'transacoes';
    }
  }





}





