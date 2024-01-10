import { Component } from '@angular/core';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-recipes-presenter',
  templateUrl: './recipes-presenter.component.html',
  styleUrls: ['./recipes-presenter.component.scss'],
})
export class RecipesPresenterComponent {
  recipeList!: Recipe[];

  constructor(private _recipeService: RecipeService) {}

  async ngOnInit(): Promise<void> {
    this.recipeList = await this._recipeService.getAllRecipes();
  }
}
