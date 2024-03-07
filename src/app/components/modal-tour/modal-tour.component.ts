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

  messages: string[] = ['Mensagem 1', 'Mensagem 2', 'Mensagem 3']; // Adicione quantas mensagens desejar
  images: string[] = ['url_da_imagem_1', 'url_da_imagem_2', 'url_da_imagem_3']; // Adicione URLs das imagens correspondentes
  currentMessage: string = this.messages[0];
  currentImage: string = this.images[0];
  currentIndex: number = 0;
  hideMessage: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.currentMessage = this.messages[this.currentIndex];
    this.currentImage = this.images[this.currentIndex];
  }

  next() {
    this.currentIndex = (this.currentIndex + 1) % this.messages.length;
    this.currentMessage = this.messages[this.currentIndex];
    this.currentImage = this.images[this.currentIndex];
  }

  closeModal() {
    alert('Modal fechado');
    this.router.navigate(['/home']);
  }
}
