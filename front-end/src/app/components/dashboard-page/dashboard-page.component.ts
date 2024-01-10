import { Component, OnInit } from '@angular/core';
import { RecipeService } from 'src/app/services/recipe.service';
import { Recipe } from 'src/app/interfaces/recipe.interface';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss'],
})
export class DashboardPageComponent implements OnInit {
  recipe_list!: Recipe[];

  constructor(private _recipeService: RecipeService) {}

  async ngOnInit(): Promise<void> {
    this.recipe_list = await this._recipeService.getAllRecipes();
  }
}
