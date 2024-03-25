import { CommonModule } from '@angular/common';
import { Component} from '@angular/core';
import { FormsModule} from '@angular/forms';

@Component({
  selector: 'app-withdrawal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './withdrawal.component.html',
  styleUrl: './withdrawal.component.scss'
})
export class WithdrawalComponent {
  
  
  currentBalance: number = 1000; // Exemplo de saldo atual
  withdrawalValue: number | undefined;
  showInput: boolean = false;

  selectValue(value: number) {
    this.withdrawalValue = value;
    this.showInput = false; // Esconder o campo de entrada ao selecionar um valor sugerido
  }

  openInput() {
    this.showInput = true; // Mostrar o campo de entrada para digitar outro valor
  }
  
  requestWithdrawal() {
    if (this.withdrawalValue! <= this.currentBalance) {
      // Lógica para solicitar o saque
      console.log('Saque solicitado:', this.withdrawalValue);
    } else {
      alert('Saldo insuficiente!');
    }
  }
}
