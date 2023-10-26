import { Component } from '@angular/core';
import { Recipe } from '../interfaces/recipe.interface';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss']
})
export class RecipePageComponent {
  //Variables
  //For test at the moment, to be sure stuff works
    recipeTest: Recipe ={
    Id: 1,
    Name: "Pasta",
    Description: "Pasta with tomato sauce",
    Ingredients: [],
    ImageURL: ""
  }



  //Functions


}
