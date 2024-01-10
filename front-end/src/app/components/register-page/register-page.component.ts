import { Component, OnInit } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormControl,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { NzFormTooltipIcon } from 'ng-zorro-antd/form';
import { User } from '../../interfaces/user.interface';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss'],
})
export class RegisterPageComponent {
  newUser!: User;
  registerForm!: UntypedFormGroup;

  constructor(
    private fb: UntypedFormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstName: [null , [Validators.required, Validators.minLength(3)]],
      lastName: [null , [Validators.required, Validators.minLength(3)]],
      username: [null, [Validators.required, Validators.minLength(3)]],
      password: [null, [Validators.required, Validators.minLength(3)]],
      checkPassword: [null, [Validators.required, Validators.minLength(3)]],
    });
  }

  checkPasswordsMatch(): boolean {
    return (
      this.registerForm.value.password === this.registerForm.value.checkPassword
    );
  }

  registerClick() {
    if (!this.checkPasswordsMatch()) {
      alert("Passwords don't match!");
      return;
    }

    this.newUser = {
      id: '',
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      userName: this.registerForm.value.username,
      password: this.registerForm.value.password,
    };

    this.userService.register(this.newUser);
    alert('Registration successful!');
    this.router.navigate(['/login']);
  }

  //Se intoarce la pagina de login
  cancelClick() {
    console.log('cancelClick');
    this.router.navigate(['/login']);
  }
}
