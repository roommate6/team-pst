import { Component } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  ReactiveFormsModule,
} from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent {
  //Declaratii
  loginForm!: UntypedFormGroup;

  constructor(
    private router: Router,
    private userService: UserService,
    private fb: UntypedFormBuilder
  ) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      username: [null, [Validators.required, Validators.minLength(3)]],
      password: [null, [Validators.required, Validators.minLength(3)]],
      remember: [true],
    });
  }

  userIsValid(): boolean {
    return this.userService.checkUser(
      this.loginForm.value.username,
      this.loginForm.value.password
    );
  }

  loginClick() {
    if (this.userIsValid()) {
      this.router.navigate(['/menu']);
    } else {
      alert('Username or password is incorrect!');
    }
  }
}
