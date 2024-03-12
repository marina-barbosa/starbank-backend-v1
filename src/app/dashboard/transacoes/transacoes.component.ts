import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { CentralComponent } from '../central/central.component';

@Component({
  selector: 'app-transacoes',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterOutlet, CentralComponent],
  templateUrl: './transacoes.component.html',
  styleUrl: './transacoes.component.scss'
})
export class TransacoesComponent {


  user: {
    name: string,
    saldoTotal: number,
    momento: Date,
    transacoes: {
      id: number,
      tipo: string,
      data: Date,
      detalhes: string,
      valor: number
    }[],
    avatar: string,
    cartao: {
      numero: string,
      titular: string,
      validade: string,
      cvv: string,
      tipo: string
    }
  };

  filtroTipo: string = 'todas';
  pageSize: number = 5;
  currentPage: number = 1;




  getTotalPages(): number[] {
    const total = Math.ceil(this.getFilteredTransactions().length / this.pageSize);
    return Array(total).fill(0).map((x, i) => i + 1);
  }

  getVisibleTransactions(): any[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    return this.getFilteredTransactions().slice(startIndex, startIndex + this.pageSize);
  }

  getFilteredTransactions(): any[] {
    if (this.filtroTipo === 'todas') {
      return this.user.transacoes;
    } else {
      return this.user.transacoes.filter(transacao => transacao.tipo === this.filtroTipo);
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  nextPage(): void {
    if (this.currentPage < this.getTotalPages().length) {
      this.currentPage++;
    }
  }

  onFilterChange(): void {
    this.currentPage = 1; // reset da page
  }


  constructor() {


    this.user = {

      name: 'Admin',
      saldoTotal: 854500,
      momento: new Date(),
      transacoes: [
        {
          id: 1,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Reembolso',
          valor: 500.00
        },
        {
          id: 2,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Saque ATM',
          valor: -200.00
        },
        {
          id: 3,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra Online',
          valor: -300.00
        },
        {
          id: 4,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra online',
          valor: -300.00
        },
        {
          id: 5,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Salário',
          valor: 3700.00
        },
        {
          id: 6,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Reembolso 2',
          valor: 500.00
        },
        {
          id: 7,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Saque ATM 2',
          valor: -200.00
        },
        {
          id: 8,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra Online 2',
          valor: -300.00
        },
        {
          id: 9,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra online 2',
          valor: -300.00
        },
        {
          id: 10,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Salário 2',
          valor: 3700.00
        },
        {
          id: 11,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Reembolso 3',
          valor: 500.00
        },
        {
          id: 12,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Saque ATM 3',
          valor: -200.00
        },
        {
          id: 13,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra Online 3',
          valor: -300.00
        },
        {
          id: 14,
          tipo: 'saída',
          data: new Date(),
          detalhes: 'Compra online 3',
          valor: -300.00
        },
        {
          id: 15,
          tipo: 'entrada',
          data: new Date(),
          detalhes: 'Salário 3',
          valor: 3700.00
        }
      ],
      avatar: '../../../assets/perfil.png',
      cartao: {
        numero: '1234 5678 9012 3456',
        titular: 'Admin',
        validade: '12/2000',
        cvv: '689',
        tipo: 'Mastercard'
      }
    };

  }



}
