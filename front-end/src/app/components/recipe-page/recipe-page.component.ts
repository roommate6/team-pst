import { Component } from '@angular/core';
import { Recipe } from '../../interfaces/recipe.interface';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss'],
})
export class RecipePageComponent {
  stepNumber: number = 1;

  recipeTest: Recipe = {
    id: 22,
    name: 'Pasta',
    shortDescription:
      "Description for yummy pasta. This description is very long and should be cut off at some point. I don't know how long it should be, but it should be long enough to test if the text is cut off.",
    ingredients: [
      {
        id: 2,
        name: 'Pasta',
        imageId: 1,
      },
      {
        id: 3,
        name: 'Tomato sauce',
        imageId: 1,
      },
    ],
    imageId: 19,
  };
}
