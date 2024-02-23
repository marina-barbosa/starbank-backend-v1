import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { FormsModule, NgModel } from '@angular/forms';
import { User } from '../../../Models/User';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  users:User[] = [];

  formulario = new FormGroup({
    fullName: new FormControl(''),
    cpf: new FormControl(''),
    phone: new FormControl(''),
    address: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl('')
  });

  constructor(private userService: UserService) {}

  registerUser(): void {
    if(this.validatePasswordMatch()) {
      this.userService.registerUser(this.formulario.value as User);
      alert('Cadastro de usuário realizado com sucesso!')
      this.formulario.reset();
    } else {
      alert('As senhas não coincidem.');
    }
  }
  private validatePasswordMatch(): boolean {
    return this.formulario.value.password === this.formulario.value.confirmPassword;
  }

}
