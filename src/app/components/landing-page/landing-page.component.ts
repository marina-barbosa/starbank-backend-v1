import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent {

  active: boolean = false;

  accordionItems = [
    {
      title: 'Como faço para abrir uma conta?',
      content: 'Para abrir uma conta conosco, basta preencher nosso formulário de inscrição online em nossa página de cadastro. É simples e rápido!',
      active: false
    },
    {
      title: 'Quais são as taxas associadas à minha conta?',
      content: 'Não cobramos taxas de manutenção de conta. No entanto, algumas transações podem estar sujeitas a taxas. Consulte nossa página de tarifas para obter mais informações.',
      active: false
    },
    {
      title: 'Como faço para entrar em contato com o suporte ao cliente?',
      content: 'Você pode entrar em contato conosco por telefone, e-mail ou através do nosso chat online disponível em nosso aplicativo móvel.',
      active: false
    },
    {
      title: 'Como alterar minha senha?',
      content: 'Para alterar sua senha, faça login em sua conta e vá para as configurações de perfil. Lá você encontrará a opção para alterar sua senha.',
      active: false
    },
    {
      title: 'Onde posso encontrar meu número de conta?',
      content: 'Seu número de conta está disponível no menu da sua conta, logo abaixo do seu nome de usuário.',
      active: false
    },
    {
      title: 'Como posso depositar fundos em minha conta?',
      content: 'Você pode depositar fundos em sua conta através de transferência bancária, cartão de crédito ou serviços de pagamento eletrônico disponíveis em nossa plataforma.',
      active: false
    },
    {
      title: 'É possível cancelar uma transação?',
      content: 'Infelizmente, uma vez que uma transação é processada, não é possível cancelá-la. Por favor, revise cuidadosamente todas as informações antes de confirmar uma transação.',
      active: false
    },
    {
      title: 'Como faço para solicitar um empréstimo?',
      content: 'Atualmente, não oferecemos serviços de empréstimo em nossa plataforma. No entanto, estamos trabalhando para disponibilizar essa opção no futuro.',
      active: false
    }
  ];

  toggleAccordion(item: { active: boolean }) {
    item.active = !item.active;
  }

}
