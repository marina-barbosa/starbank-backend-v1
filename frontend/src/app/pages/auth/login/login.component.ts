import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalTourComponent } from '../../../components/modal-tour/modal-tour.component';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, FormsModule, CommonModule, ReactiveFormsModule, ModalTourComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

// export class LoginComponent implements OnInit  {

//   loginForm: FormGroup;
//   errorMessage: string | undefined;
//   showTour: boolean = true;

//   constructor(private router: Router) {
//     this.loginForm = new FormGroup({
//       username: new FormControl('', [Validators.required]),
//       password: new FormControl('', [Validators.required]),
//     });
//   }

//   ngOnInit(): void {
//   }

//   onSubmit() {
//     if (this.loginForm.valid) {
//       const { username, password } = this.loginForm.value;

//       if (username === 'admin' && password === 'admin') {
//         this.router.navigate(['/lottie']);
//         // if(this.showTour = true){
//         //   // abrir o componente modalTour
//         //   this.router.navigate(['/tour']);
//         // } else {
//         //   this.router.navigate(['/home']);
//         // }
//       } else {
//         this.errorMessage = 'Credenciais inválidas.';
//       }
//     }
//   }
// }

export class LoginComponent {
  cpf: string = '';
  password: string = '';
  loginError: boolean = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    // Verificar se há um usuário autenticado ao carregar a página
    const currentUser = this.userService.getCurrentUser();

    if (currentUser) {
      console.log('Usuário já autenticado. Redirecionando...');
      this.router.navigate(['/página-de-sucesso']); // Substitua pelo caminho desejado
    }
  }

  loginUser(): void {
    const loginSuccess = this.userService.login(this.cpf, this.password);
    if (loginSuccess) {
      // Redirecionar para a página de sucesso ou realizar ações desejadas
      console.log('Redirecionando para a página de sucesso...');
      this.router.navigate(['register']); // Substitua pelo caminho desejado
    } else {
      this.loginError = true;
      // Exibir mensagem de erro ou realizar ações desejadas para login falhado
    }
  }

}




