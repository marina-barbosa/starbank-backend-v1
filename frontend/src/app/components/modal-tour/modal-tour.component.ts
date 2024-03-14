import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-modal-tour',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './modal-tour.component.html',
  styleUrl: './modal-tour.component.scss'
})
export class ModalTourComponent {

  images: string[] = ['../../../assets/modal/img1.png', '../../../assets/modal/pix.png', '../../../assets/modal/economize.png', '../../../assets/modal/pagar-conta.png', '../../../assets/modal/cartoes.png', '../../../assets/modal/recarga.png'];
  titles: string[] = ['Star Bank', 'Pix', 'Economize seu Dinheiro', 'Pagar Contas', 'Cartões', 'Recarga de Celular'];
  messages: string[] = [
    'Sua jornada financeira, guiada pelo brilho da inovação',
    'Acelere suas transações com a eficiência do Pix. Transferências instantâneas que proporcionam conveniência e agilidade em cada movimento financeiro',
    'Acompanhe o progresso de suas economias e crie o hábito de economizar com Star Pay.',
    'Descomplicamos o processo de pagamento de contas, permitindo que você se concentre no essencial. Na Star Pay, cada transação é uma experiência simples e eficaz.',
    'Eleve sua experiência financeira com nossos cartões virtuais. Transações seguras e flexíveis, disponíveis em qualquer lugar. Com a Star Pay, a modernidade está ao alcance dos seus dedos',
    'Mantenha-se conectado com nossa opção de recarga de celular. Uma solução moderna e ágil para garantir que você esteja sempre em contato'
  ];
  slider: string[] = ['../../../assets/modal/slider-inicio.png', '../../../assets/modal/slider-meio.png', '../../../assets/modal/slider-meio.png', '../../../assets/modal/slider-meio.png', '../../../assets/modal/slider-meio.png', '../../../assets/modal/slider-fim.png'];
  currentImage: string = this.images[0];
  currentTitle: string = this.titles[0];
  currentMessage: string = this.messages[0];
  currentSlider: string = this.slider[0];
  currentButton: string = 'Comece agora';
  currentIndex: number = 0;
  hideMessage: boolean = false;
  lastModal: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.currentMessage = this.messages[this.currentIndex];
    this.currentImage = this.images[this.currentIndex];
  }

  next() {
    this.currentIndex = (this.currentIndex + 1) % this.messages.length;
    this.currentImage = this.images[this.currentIndex];
    this.currentTitle = this.titles[this.currentIndex];
    this.currentMessage = this.messages[this.currentIndex];
    this.currentSlider = this.slider[this.currentIndex];
    if (this.currentIndex == 0) {
      this.currentButton = 'Comece agora';
    } else if (this.currentIndex == 5) {
      this.currentButton = 'Fechar';
      this.lastModal = true;
    } else {
      this.currentButton = 'Proximo >';
    }
    if (this.lastModal && this.currentIndex == 0) {
      this.closeModal()
    }
  }

  closeModal() {
    this.router.navigate(['/home']);
  }
}
