import { Injectable } from '@angular/core';
import { Observable, Subject, filter } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventBusService {
  private _eventBus: Subject<any> = new Subject<any>();

  constructor() {}

  publish(event: any): void {
    this._eventBus.next(event);
  }

  subscribe(eventName: string): Observable<any> {
    return this._eventBus
      .asObservable()
      .pipe(filter((event: any) => event.name === eventName));
  }
}
