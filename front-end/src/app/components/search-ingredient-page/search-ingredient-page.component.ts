import { Component } from '@angular/core';
import { RouteReuseStrategy, Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { debounce, interval, switchMap, tap } from 'rxjs';
import recipeData from '../../services/recipes.json';

@Component({
  selector: 'app-search-ingredient-page',
  templateUrl: './search-ingredient-page.component.html',
  styleUrls: ['./search-ingredient-page.component.scss']
})
export class SearchIngredientPageComponent {

  router: Router;

  //Create a list of nz-input components with the default size
  public search_bars: FormControl[] = [new FormControl()];
  public search_terms: string[] = [''];
  numberOfTerms = 1;

  public recipe_list: Recipe[] = recipeData; // List of all the recipes
  public result_list: Recipe[] = [];        // List of the recipes that match the search term

  constructor(router: Router) {
    this.router = router;
    //Create a nz-input component with the default size
    this.search_terms.push('');
    //Set the formControl value to the search term
    this.search_bars[this.numberOfTerms-1].setValue(this.search_terms[this.numberOfTerms-1]);

  }


  addSearchBox() {
    this.search_bars.push(new FormControl());
    this.search_terms.push('');
    this.numberOfTerms++;

    //Set the formControl value to the search term
    this.search_bars[this.numberOfTerms-1].setValue(this.search_terms[this.numberOfTerms-1]);
  }


  searchRecipe() {
    //Clear the result list
    this.result_list = [];

    //Get the search terms
    for (let i = 0; i < this.numberOfTerms; i++) {
      this.search_terms[i] = this.search_bars[i].value;
    }

    //Search the recipes
    //The recipes that will be added to the result list are the ones that contain all the search terms
    for (let i = 0; i < this.recipe_list.length; i++) {
        let recipe = this.recipe_list[i];
        let ingredients = recipe.Ingredients;
        let found = true;

        //Check every term
        for (let j = 0; j < this.numberOfTerms; j++) {
          let term = this.search_terms[j];

          //Check every ingredient to see if it contains the term
          for (let k = 0; k < ingredients.length; k++) {
            let ingredient = ingredients[k];
            if (ingredient.Name.toLowerCase().includes(term.toLowerCase())) {
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


  moveToNameSearch() {
    this.router.navigate(['/name-search']);
  }

  moveToIngredientSearch() {
    this.router.navigate(['/ingredient-search']);
  }
}
