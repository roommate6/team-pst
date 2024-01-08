import { Component, Input } from '@angular/core';
import { Recipe } from '../interfaces/recipe.interface';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent {

  @Input() recipeName!: string;
  @Input() recipeDescription!: string;
  @Input() recipeImageUrl!: string;


  onRecipeClick() {
    throw new Error('Method not implemented.');
  }

  /*
  constructor(recipe: Recipe) {
    this.recipeName = recipe.Name;
    this.recipeDescription = recipe.Description;
    this.recipeImageUrl = recipe.ImageUrl;
  }*/
}
