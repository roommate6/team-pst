import { Inject } from '@angular/core';
import { User } from '../interfaces/user.interface';
import { EventBusService } from '../services/event-bus.service';

import { inject } from '@angular/core';

export class AppStateStracker {
  get loggedUser(): User {
    if (this._loggedUser === undefined) {
      throw new Error('User undefined.');
    }
    return this._loggedUser;
  }
  set loggedUser(user: User) {
    this._loggedUser = user;
  }

  private _loggedUser?: User;

  private _eventBusService!: EventBusService;

  private constructor() {
    this._eventBusService = inject(EventBusService);
  }

  static get instance(): AppStateStracker {
    if (AppStateStracker._instance === null) {
      AppStateStracker._instance = new AppStateStracker();
    }
    return AppStateStracker._instance;
  }

  private static _instance: AppStateStracker | null = null;
}
