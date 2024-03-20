import { Component, } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, } from '@angular/common';
import { NgModule } from '@angular/core';



@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule,],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})

export class RegisterComponent {
register() {
throw new Error('Method not implemented.');
}
  currentModal: number = 1;
  currentModalIndex: number = 0;

  formData: any = {
    name: '',
    email: '',
    companyName: '',
    cnpj: '',
    stateRegistration: '',
    annualRevenue: '',
    taxationType: '',
    phone: '',
    address_street: '',
    address_number: '',
    address_complement: '',
    address_neighborhood: '',
    address_city: '',
  };

  selectedState: string = '';

  states: string[] = [
    'Acre', 'Alagoas', 'Amapá', 'Amazonas', 'Bahia', 'Ceará', 'Distrito Federal',
    'Espírito Santo', 'Goiás', 'Maranhão', 'Mato Grosso', 'Mato Grosso do Sul',
    'Minas Gerais', 'Pará', 'Paraíba', 'Paraná', 'Pernambuco', 'Piauí', 'Rio de Janeiro',
    'Rio Grande do Norte', 'Rio Grande do Sul', 'Rondônia', 'Roraima', 'Santa Catarina',
    'São Paulo', 'Sergipe', 'Tocantins'
  ];

  nextModal() {
    this.currentModal++;
    this.currentModalIndex++;
  }

  goBack() {
    if (this.currentModal > 1) {
      this.currentModal--;
      this.currentModalIndex--;
    }
  }

  next() {
    console.log('Dados do formulário:', this.formData);
  }

  isValidEmail(email: string): boolean {
    return email.includes('@');
  }
}

@NgModule({
  imports: [CommonModule, FormsModule, RegisterComponent],
  declarations: [],
  exports: [RegisterComponent]
})
export class RegisterModule { };