import { Injectable } from '@angular/core';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private localStorageUser = 'userData';
  private localStorageCurrentUser = 'currentUser';

  constructor() { }

  // Método para registrar um novo usuário
  registerUser(user: User): void {
    // Adicione uma verificação para evitar adicionar usuários com campos obrigatórios vazios
    if (user && user.fullName && user.cpf && user.phone && user.address && user.password) {
      const existingUsers = this.getUsers();
      existingUsers.push(user);
      this.saveUsers(existingUsers);
    } else {
      alert('Tentativa de registrar usuário inválido. Campos obrigatórios ausentes.');
    }
  }

  // Método para obter todos os usuários armazenados
  login(cpf:string, password:string): boolean{
    const users = this.getUsers();
    const user = users.find(u => u.cpf === cpf && u.password === password);

    if(user){
      localStorage.setItem(this.localStorageUser, JSON.stringify(user));
      alert('Login bem-sucedido');
      return true;
    }else{
      alert('Falha no login. Usuário não encontrado ou senha incorreta.');
      return false;
    }
  }

  private getUsers(): User[] {
    const userData = localStorage.getItem(this.localStorageUser);
    return userData ? JSON.parse(userData) : [];
  }

  // Método para salvar os usuários no localStorage
  private saveUsers(users: User[]): void {
    localStorage.setItem(this.localStorageUser, JSON.stringify(users));
  }

  getCurrentUser(): User | null {
    const currentUserData = localStorage.getItem(this.localStorageCurrentUser);
    return currentUserData ? JSON.parse(currentUserData) : null;
  }

  logout(): void {
    localStorage.removeItem(this.localStorageCurrentUser);
  }  
}
