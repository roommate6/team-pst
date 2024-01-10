import { Injectable } from '@angular/core';
import { User } from '../interfaces/user.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiConfigurations } from '../classes/apiConfigurations';
import { EventBusService } from './event-bus.service';
import { AppStateTracker } from '../classes/appStateTracker';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private _http: HttpClient,
    private _eventBusService: EventBusService
  ) {}

  login(userName: string, password: string): void {
    const loginUrl: string = ApiConfigurations.instance.authenticationLoginUrl;
    const headers = new HttpHeaders({});

    this._http
      .post(
        loginUrl,
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
          let userFromData: User = {
            id: data.id,
            firstName: data.firstName,
            lastName: data.lastName,
            userName: data.userName,
          };
          this.setTheLoggedUserInTheAppStateTracker(userFromData);
          this.notifyThatTheLoginWasSuccessful();
        },
        error: (err: any) => {
          this.notifyThatTheLoginWasUnsuccessful();
        },
      });
  }

  register(user: User): void {
    const registerUrl: string = ApiConfigurations.instance.authenticationRegisterUrl;
    const headers = new HttpHeaders({});

    this._http
      .post(
        registerUrl,
        {
          firstName: user.firstName,
          lastName: user.lastName,
          userName: user.userName,
          password: user.password,
        },
        {
          headers: headers,
        }
      )
      .subscribe({
        next: (data: any) => {
          //this.notifyThatTheRegisterWasSuccessful();
        },
        error: (err: any) => {
          //this.notifyThatTheRegisterWasUnsuccessful();
        },
      });
  }

  private notifyThatTheLoginWasSuccessful() {
    this._eventBusService.publish({
      name: 'LOGIN_successful_login_event',
    });
  }
  private notifyThatTheLoginWasUnsuccessful() {
    this._eventBusService.publish({
      name: 'LOGIN_unsuccessful_login_event',
    });
  }

  private setTheLoggedUserInTheAppStateTracker(loggedUser: User) {
    AppStateTracker.instance.loggedUser = loggedUser;
  }
}
