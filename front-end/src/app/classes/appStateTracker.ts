import { User } from '../interfaces/user.interface';
import { EventBusService } from '../services/event-bus.service';

import { AppInjector } from '../app.module';

export class AppStateTracker {
  private static _instance: AppStateTracker | null = null;
  private _loggedUser?: User;
  private _eventBusService!: EventBusService;

  private constructor() {
    this._eventBusService = AppInjector.get(EventBusService);
  }

  get loggedUser(): User {
    if (this._loggedUser === undefined) {
      throw new Error('User undefined.');
    }
    return this._loggedUser;
  }
  set loggedUser(user: User) {
    this._loggedUser = user;
  }

  static get instance(): AppStateTracker {
    if (AppStateTracker._instance === null) {
      AppStateTracker._instance = new AppStateTracker();
    }
    return AppStateTracker._instance;
  }
}
