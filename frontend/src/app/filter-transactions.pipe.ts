import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterTransactions',
  standalone: true
})
export class FilterTransactionsPipe implements PipeTransform {

  transform(transactions: any[], filter: string): any[] {
    if (filter === "todas") {
      return transactions;
    } else {
      return transactions.filter((transaction) => transaction.tipo === filter);
    }
  }
}

