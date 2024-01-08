import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent implements OnInit {
  loginForm!: UntypedFormGroup;

  constructor(
    private _userService: UserService,
    private _untypedFormBuilder: UntypedFormBuilder,
    private _eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  handleSubmitEvent() {
    this._userService.login(
      this.loginForm.value.username,
      this.loginForm.value.password
    );
  }

  handleRegisterLinkClick() {
    this._eventBusService.publish({
      name: 'LOGIN_register_link_click_event',
    });
  }

  private initializeForm() {
    this.loginForm = this._untypedFormBuilder.group({
      username: [null, [Validators.required, Validators.minLength(3)]],
      password: [null, [Validators.required, Validators.minLength(3)]],
      remember: [true],
    });
  }
}
