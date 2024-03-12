import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { FormsModule, NgModel, Validators } from '@angular/forms';
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
  formulario = new FormGroup({
    fullName: new FormControl('', Validators.required),
    cpf: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required)
  });
  

  constructor(private userService: UserService, private router: Router) { }


  registerUser(): void {
    
    if (this.formulario.valid) {      
      if (this.validatePasswordMatch()) {
        this.userService.registerUser(this.formulario.value as User);
        alert('Cadastro de usuário realizado com sucesso!');
        this.router.navigate(['/login']);
        
      } else {
        alert('As senhas não coincidem.');
      }
    } else {
      alert('Por favor, preencha todas as informações do usuário.');
    }
  }

  validatePasswordMatch(): boolean {
    const senhaControl = this.formulario.get('password');
    const confirmarSenhaControl = this.formulario.get('confirmPassword');

    if (senhaControl && confirmarSenhaControl && senhaControl.value !== null && confirmarSenhaControl.value !== null) {
      const senha = senhaControl.value.trim();
      const confirmarSenha = confirmarSenhaControl.value.trim();

      return senha === confirmarSenha;
    }
    return false;
  }
} 
