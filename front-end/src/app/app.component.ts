import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventBusService } from './services/event-bus.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(
    private _router: Router,
    private _eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.initializeEventBusListeners();
    this._router.navigate(['dashboard']);
  }

  private initializeEventBusListeners() {
    this._eventBusService
      .subscribe('LOGIN_successful_login_event')
      .subscribe((event: any) => {
        this._router.navigate(['dashboard']);
      });

    this._eventBusService
      .subscribe('LOGIN_unsuccessful_login_event')
      .subscribe((event: any) => {
        alert('The username or password is wrong.');
      });

    this._eventBusService
      .subscribe('LOGIN_register_link_click_event')
      .subscribe((event: any) => {
        this._router.navigate(['register']);
      });
  }
}
