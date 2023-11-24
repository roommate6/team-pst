import { PathLocationStrategy } from '@angular/common';
import { Component } from '@angular/core';
import { Ingredient } from '../interfaces/ingredient.interface';
import { Recipe } from '../interfaces/recipe.interface';
import { StepCardComponent } from '../step-card/step-card.component';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss']
})
export class RecipePageComponent {
  //Variables
  stepNumber: number = 1;


  //For test at the moment, to be sure stuff works
    recipeTest: Recipe = {
    Name: "Pasta",
    Description: "Description for yummy pasta. This description is very long and should be cut off at some point. I don't know how long it should be, but it should be long enough to test if the text is cut off.",
    Steps: ["Boil water and wait for it to boil and I add text to testand I add text to testand I add text to testand and I add text to testand I add text to testand I add text to testand I add text to testand I add text to testI add text to test", "Add pasta", "Cook for 10 minutes", "Drain water", "Add sauce"],
    Ingredients: [
      {
        Name: "Pasta",
        Description: "Pasta",
        Unit: "g",
        ImageURL: ""
      },
      {
        Name: "Tomato sauce",
        Description: "Tomato sauce",
        Unit: "g",
        ImageURL: ""
      }
    ],
    ImageURL: "/assets/img.png"
  }



  //Functions


}
