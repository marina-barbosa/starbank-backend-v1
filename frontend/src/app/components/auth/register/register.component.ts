import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../../services/user.service';
import { FormsModule, NgModel, Validators } from '@angular/forms';
import { User } from '../../../Models/User';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';



@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, ReactiveFormsModule,],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'


}) export class RegisterComponent {
  formDataModal1: any = {
    nome: '',
    cpf: '',
    email: '',
    phone: '',
  };

  formDataModal2: any = {
    adress: {
      street: '',
      number: 0,
      complement: '',
      neighborhood: '',
      city: '',
      state: '',
      zipCode: '',
      country: 'Brasil'
    }
  };


  formDataModal3Data: any = {
    acceptTerms: false
  }; // Objeto para armazenar o estado do checkbox

  modal3Title: string = 'Modal 3';
  modal3Message: string = 'Por favor, aceite os termos abaixo:';


  formDataModal4: any = {
    password: '',
    confirmPassword: '',
    passwordSecurity: '',
    confirmPasswordSecurity: ''
  };
}