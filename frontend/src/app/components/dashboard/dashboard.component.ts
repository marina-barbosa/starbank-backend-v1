import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {paymentOptions = [
  { title: 'Transferência Bancária', description: 'Realize transferências bancárias de forma rápida e segura.' },
  { title: 'PIX', description: 'Faça pagamentos instantâneos utilizando o PIX.' },
  // Outras opções de pagamento...
];

selectPaymentOption(option: any): void {
  // Lógica para lidar com a seleção da opção de pagamento
  console.log('Opção de pagamento selecionada:', option);
}


}
