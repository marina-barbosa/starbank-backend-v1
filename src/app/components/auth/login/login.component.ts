import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { User } from '../../../Models/User';
import { FormControl, FormGroup, FormsModule } from '@angular/forms';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  cpf: string = '';
  password: string = '';
  loginError: boolean = false;

  constructor(private userService: UserService, private router: Router){}

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
