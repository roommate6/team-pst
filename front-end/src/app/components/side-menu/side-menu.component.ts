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

  moveToNameSearch() {
    this.router.navigate(['/name-search']);
  }

  moveToIngredientSearch() {
    this.router.navigate(['/ingredient-search']);
  }
}
