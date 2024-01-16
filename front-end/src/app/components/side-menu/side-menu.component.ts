import { Component } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { IngredientPageComponent } from '../ingredient-page/ingredient-page.component';
import { RecipePageComponent } from '../recipe-page/recipe-page.component';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss'],
})
export class SideMenuComponent {
  constructor(private router: Router) {}

  ngOnInit(): void {}

  moveToDashboard() {
    this.router.navigate(['dashboard', 'home']);
  }

  moveToNameSearch() {
    this.router.navigate(['dashboard', 'name-search']);
  }

  moveToIngredientSearch() {
    this.router.navigate(['dashboard', 'ingredient-search']);
  }

  moveToUserPage() {
    this.router.navigate(['dashboard', 'user']);
  }

  moveToAboutPage() {
    this.router.navigate(['dashboard', 'about']);
  }
}
