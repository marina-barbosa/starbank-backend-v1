import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss'
})
export class FooterComponent{

  // selectedItem: any;
  // listItems = [
  //   { text: 'Pix', icon: 'fa-brands fa-pix' },
  //   { text: 'Carteira', icon: 'fa-solid fa-wallet' },
  //   { text: 'QR-Code', icon: 'fa-solid fa-qrcode', active: true },
  //   { text: 'Cartão', icon: 'fa-regular fa-credit-card' },
  //   { text: 'Transação', icon: 'bi bi-arrow-down-up' }
  // ];

  // ngOnInit() {
  //   this.selectedItem = this.listItems.find(item => item.text === 'QR-Code');
  // }

  // selectItem(item: any) {
  //   this.selectedItem = item;
  // }
}
