import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import recipeData from '../../services/recipes.json';
import { IngredientService } from 'src/app/services/ingredient.service';
import { Ingredient } from 'src/app/models/ingredient';

@Component({
  selector: 'app-search-ingredient-page',
  templateUrl: './search-ingredient-page.component.html',
  styleUrls: ['./search-ingredient-page.component.scss'],
})
export class SearchIngredientPageComponent implements OnInit {

  public ingredientList: Ingredient[] = [];
  public selectedIngredientList: Ingredient[] = [];

  constructor(private ingredientService: IngredientService) {}

  //Create a list of nz-input components with the default size
  public searchBars: FormControl[] = [new FormControl()];
  public search_terms: string[] = [''];
  numberOfTerms = 1;

  public recipe_list: Recipe[] = recipeData; // List of all the recipes
  public result_list: Recipe[] = []; // List of the recipes that match the search term

  async ngOnInit(): Promise<void> {
    this.ingredientList = await this.ingredientService.getAllIngredients();
    this.selectedIngredientList = this.ingredientList;
  }

  // constructor() {
  //   //Create a nz-input component with the default size
  //   this.search_terms.push('');
  //   //Set the formControl value to the search term
  //   this.searchBars[this.numberOfTerms - 1].setValue(
  //     this.search_terms[this.numberOfTerms - 1]
  //   );
  // }

  addSearchBox() {
    this.searchBars.push(new FormControl());
    this.search_terms.push('');
    this.numberOfTerms++;

    //Set the formControl value to the search term
    this.searchBars[this.numberOfTerms - 1].setValue(
      this.search_terms[this.numberOfTerms - 1]
    );
  }

  searchRecipe() {
    //Clear the result list
    this.result_list = [];

    //Get the search terms
    for (let i = 0; i < this.numberOfTerms; i++) {
      this.search_terms[i] = this.searchBars[i].value;
      console.log(this.searchBars[i].value);
    }

    //Search the recipes
    //The recipes that will be added to the result list are the ones that contain all the search terms
    for (let i = 0; i < this.recipe_list.length; i++) {
      let recipe = this.recipe_list[i];
      let ingredients = recipe.ingredients;
      let found = true;

      //Check every term
      for (let j = 0; j < this.numberOfTerms; j++) {
        let term = this.search_terms[j];

        //Check every ingredient to see if it contains the term
        for (let k = 0; k < ingredients.length; k++) {
          let ingredient = ingredients[k];
          if (ingredient.name.toLowerCase().includes(term.toLowerCase())) {
            found = true;
            break;
          } else {
            found = false;
          }
        }
        //If the term was not found in any of the ingredients, break the loop
        if (!found) {
          break;
        }
      }

      //If the recipe contains all the terms, add it to the result list
      if (found) {
        this.result_list.push(recipe);
      }
    }
  }
}
