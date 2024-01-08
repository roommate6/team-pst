import { PathLocationStrategy } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { Component, Input } from '@angular/core';
import { Ingredient } from '../interfaces/ingredient.interface';
import { Recipe } from '../interfaces/recipe.interface';
import { IngredientListComponent } from '../ingredient-list/ingredient-list.component';
@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss']
})
export class RecipePageComponent {
  //Variables
  stepNumber: number = 1;
  @Input() inputRecipe!: Recipe;

  //For test at the moment, to be sure stuff works
    testRecipe: Recipe = {
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

  //Momentan doar pentru test ca ia valorile
  //Eventual se va cauta un recipe cu numele / ingredientele dorite
  ngOnInit(): void {
    this.inputRecipe=this.testRecipe;
  }

  constructor(private router: Router){}

  moveToRecipe() {
    this.router.navigate(['/recipe']);
  }

  moveToIngredient() {
    this.router.navigate(['/ingredient']);
  }
}

