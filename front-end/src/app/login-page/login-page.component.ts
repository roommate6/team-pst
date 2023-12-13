import { Component } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {
  constructor(private router: Router) { }

  login(){
    this.router.navigate(['/recipe']);
  }
}
