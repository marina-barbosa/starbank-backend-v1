import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavigationService } from '../../services/navigation.service';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent {

  navigationItems = [
    { icon: 'fa-brands fa-pix', text: 'Pix', id: 'pix', active: false },
    { icon: 'fa-solid fa-wallet', text: 'Carteira', id: 'central', active: false },
    { icon: 'fa-solid fa-qrcode', text: 'QR-Code', id: 'pagamento', active: true },
    { icon: 'fa-regular fa-credit-card', text: 'Cartão', id: 'cartao', active: false },
    { icon: 'fa-solid fa-arrow-right-arrow-left', text: 'Transação', id: 'transacoes', active: false }
  ];

  selectedComponent: string = 'central';

  constructor(private navigationService: NavigationService) { }

  ngOnInit(): void { }

  onItemClick(item: any) {
    // coloca todos em false
    this.navigationItems.forEach(x => x.active = false);
    // coloca o item clicado em true
    item.active = true;
  }

  chooseComponent($event: any) {
    if ($event.srcElement.id === 'central') {
      this.navigationService.changeSelectedComponent('central');
    } else if ($event.srcElement.id === 'transacoes') {
      this.navigationService.changeSelectedComponent('transacoes');
    }
  }

}
