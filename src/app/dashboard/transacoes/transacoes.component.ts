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
      detalhes: string[],
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


  currentPage = 1;
  pageSize = 10;

  get paginatedTransactions() {
    const start = (this.currentPage - 1) * this.pageSize;
    const end = start + this.pageSize;
    return this.user.transacoes.slice(start, end);
  }

  get hasPreviousPage() {
    return this.currentPage > 1;
  }

  get hasNextPage() {
    return this.currentPage < Math.ceil(this.user.transacoes.length / this.pageSize);
  }

  goToPreviousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  goToNextPage() {
    if (this.currentPage < Math.ceil(this.user.transacoes.length / this.pageSize)) {
      this.currentPage++;
    }
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
          detalhes: ['Conta corrente', 'Reembolso'],
          valor: 500.00
        },
        {
          id: 2,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Conta corrente', 'Saque ATM'],
          valor: -200.00
        },
        {
          id: 3,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Lorem Ipsum', 'Compra Online'],
          valor: -300.00
        },
        {
          id: 4,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Cartão de Crédito', 'Compra online'],
          valor: -300.00
        },
        {
          id: 5,
          tipo: 'entrada',
          data: new Date(),
          detalhes: ['Conta Corrente', 'Salário'],
          valor: 3700.00
        },
        {
          id: 6,
          tipo: 'entrada',
          data: new Date(),
          detalhes: ['Conta corrente', 'Reembolso 2'],
          valor: 500.00
        },
        {
          id: 7,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Conta corrente', 'Saque ATM 2'],
          valor: -200.00
        },
        {
          id: 8,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Lorem Ipsum', 'Compra Online 2'],
          valor: -300.00
        },
        {
          id: 9,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Cartão de Crédito', 'Compra online 2'],
          valor: -300.00
        },
        {
          id: 10,
          tipo: 'entrada',
          data: new Date(),
          detalhes: ['Conta Corrente', 'Salário 2'],
          valor: 3700.00
        },
        {
          id: 11,
          tipo: 'entrada',
          data: new Date(),
          detalhes: ['Conta corrente', 'Reembolso 3'],
          valor: 500.00
        },
        {
          id: 12,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Conta corrente', 'Saque ATM 3'],
          valor: -200.00
        },
        {
          id: 13,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Lorem Ipsum', 'Compra Online 3'],
          valor: -300.00
        },
        {
          id: 14,
          tipo: 'saída',
          data: new Date(),
          detalhes: ['Cartão de Crédito', 'Compra online 3'],
          valor: -300.00
        },
        {
          id: 15,
          tipo: 'entrada',
          data: new Date(),
          detalhes: ['Conta Corrente', 'Salário 3'],
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

  ngOnInit(): void {
    const detalhes = document.querySelector('.detalhes') as HTMLTableCellElement;

    function atualizarColspan() {
      if (window.innerWidth <= 735) {
        detalhes.colSpan = 1;
      } else {
        detalhes.colSpan = 2;
      }

    }

    window.addEventListener('load', atualizarColspan);
    window.addEventListener('resize', atualizarColspan);

  }




}