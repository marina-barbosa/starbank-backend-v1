import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalTourComponent } from '../../modal-tour/modal-tour.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink, FormsModule, CommonModule, ReactiveFormsModule, ModalTourComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit  {

  loginForm: FormGroup;
  errorMessage: string | undefined;
  showTour: boolean = true;

  constructor(private router: Router) {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;

      if (username === 'admin' && password === 'admin') {
        this.router.navigate(['/lottie']);
        // if(this.showTour = true){
        //   // abrir o componente modalTour
        //   this.router.navigate(['/tour']);
        // } else {
        //   this.router.navigate(['/home']);
        // }
      } else {
        this.errorMessage = 'Credenciais inválidas.';
      }
    }
  }


}



