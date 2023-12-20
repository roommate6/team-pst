import { Injectable } from '@angular/core';
import { User } from '../interfaces/user.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiConfigurations } from '../classes/apiConfigurations';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  currentUser?: User;
  constructor(private http: HttpClient) {}

  login(userName: string, password: string): void {
    const url: string = ApiConfigurations.instance.authenticationLoginUrl;
    const headers = new HttpHeaders({});

    let logedUser: User;
    this.http
      .post(
        url,
        {
          userName: userName,
          password: password,
        },
        {
          headers: headers,
        }
      )
      .subscribe({
        next: (data: any) => {
          logedUser = {
            id: data.id,
            firstName: data.firstName,
            lastName: data.lastName,
            userName: data.userName,
          };
          console.log(logedUser);
        },
      });
  }
}
