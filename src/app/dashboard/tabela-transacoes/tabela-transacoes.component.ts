import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tabela-transacoes',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './tabela-transacoes.component.html',
  styleUrl: './tabela-transacoes.component.scss'
})
export class TabelaTransacoesComponent {

  transacoes: {
    id: number,
    tipo: string,
    data: Date,
    detalhes: string,
    valor: number
  }[];

  filtroTipo: string = 'todos';
  pageSize: number = 3;
  currentPage: number = 1;

  constructor() {
    this.transacoes = [
      { id: 1, tipo: 'Compra', data: new Date(), detalhes: 'Detalhes da compra', valor: 100 },
      { id: 2, tipo: 'Venda', data: new Date(), detalhes: 'Detalhes da venda', valor: 150 },
      { id: 3, tipo: 'Transferência', data: new Date(), detalhes: 'Detalhes da transferência', valor: 200 },
      { id: 4, tipo: 'Compra', data: new Date(), detalhes: 'Detalhes da compra', valor: 100 },
      { id: 5, tipo: 'Venda', data: new Date(), detalhes: 'Detalhes da venda', valor: 150 },
      { id: 6, tipo: 'Transferência', data: new Date(), detalhes: 'Detalhes da transferência', valor: 200 },
      { id: 7, tipo: 'Transferência', data: new Date(), detalhes: 'Detalhes da transferência', valor: 100 },
      { id: 8, tipo: 'Venda', data: new Date(), detalhes: 'Detalhes da venda', valor: 150 },
      { id: 9, tipo: 'Transferência', data: new Date(), detalhes: 'Detalhes da transferência', valor: 200 },
    ];
  }

  getTotalPages(): number[] {
    const total = Math.ceil(this.getFilteredTransactions().length / this.pageSize);
    return Array(total).fill(0).map((x, i) => i + 1);
  }

  getVisibleTransactions(): any[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    return this.getFilteredTransactions().slice(startIndex, startIndex + this.pageSize);
  }

  getFilteredTransactions(): any[] {
    if (this.filtroTipo === 'todos') {
      return this.transacoes;
    } else {
      return this.transacoes.filter(transacao => transacao.tipo === this.filtroTipo);
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

}
