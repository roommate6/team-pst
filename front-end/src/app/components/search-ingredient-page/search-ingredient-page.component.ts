import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { IngredientService } from 'src/app/services/ingredient.service';
import { Ingredient } from 'src/app/models/ingredient';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-search-ingredient-page',
  templateUrl: './search-ingredient-page.component.html',
  styleUrls: ['./search-ingredient-page.component.scss'],
})
export class SearchIngredientPageComponent implements OnInit {
  public ingredients: Ingredient[] = [];
  public selectedIngrediens: Ingredient[] = [];
  public resultedRecipes: Recipe[] = [];

  constructor(
    private _ingredientService: IngredientService,
    private _recipeService: RecipeService
  ) {}

  async ngOnInit(): Promise<void> {
    this.ingredients = await this._ingredientService.getAllIngredients();
  }

  async searchRecipes(): Promise<void> {
    this.resultedRecipes = await this._recipeService.getRecipesByIngredients(
      this.selectedIngrediens
    );
  }
}
