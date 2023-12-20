import { Injectable } from '@angular/core';
import { User } from '../interfaces/user.interface';
import userData from '../services/users.json';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  //Placeholder list of users
  //O sa fie luat dintr-o baza de date sau direct o sa schimbam
  //pentru a verifica doar o singura valouare
  public userList: User[] = userData

  get users(): User[] {
    return this.userList;
  }

  constructor() { }

  checkUser(Username: string, Password: string): boolean {
    console.log(Username);
    console.log(Password);
    for (let user of this.userList) {
      console.log(user.Username);
      console.log(user.Password);
      if (user.Username == Username && user.Password == Password) {
        return true;
      }
    }
    return false;
  }

  //Fucntie pentru a verifica daca un username exista in lista de useri
  checkUsername(username: string): boolean {
    for (let user of this.userList) {
      if (user.Username == username) {
        return true;
      }
    }
    return false;
  }

  checkPassword(Password: string): boolean {
    for (let user of this.userList) {
      if (user.Password == Password) {
        return true;
      }
    }
    return false;
  }

  //Functie pentru a adauga un user in lista de useri
  addUser(user: User): void {
    userData.push(user);
  }

}
