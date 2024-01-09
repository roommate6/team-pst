import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { debounce, interval, of, switchMap, tap } from 'rxjs';
import recipeData from '../../services/recipes.json';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-search-name-page',
  templateUrl: './search-name-page.component.html',
  styleUrls: ['./search-name-page.component.scss'],
})
export class SearchNamePageComponent {
  searchTerm = '';
  searchWord: FormControl = new FormControl();

  public recipe_list: Recipe[] = recipeData; // List of all the recipes
  public result_list: Recipe[] = [];        // List of the recipes that match the search term
  isLoading = false;

  //List of the cards with the steps
  recipeCardList: RecipeCardComponent[] = [];
  recipeCard: RecipeCardComponent = new RecipeCardComponent();
  router: Router;



  constructor(router: Router) {
    this.router = router;
  }




  ngOnInit(): void {
    console.log('Search page accessed!');

    this.searchWord.setValue(this.searchTerm);
    this.searchWord.valueChanges
      .pipe(
        tap(() => (this.isLoading = true)),
        debounce(() => interval(1000)),
        switchMap((value) => this.searchRecipes(value))
      )
      .subscribe(
        (res) => {
          this.result_list = res;
          this.isLoading = false;
        },
        (err) => {
          console.error(err.error);
        }
      );
  }


  /*WAS USING FOR TESTING THE BASIC SEARCH, MAY NOT USE IT IN THE FINAL PROJECT
    WIL BE DELETED LATER IF NECESSARY  */
  searchRecipes(keyword: string) {
    // Call your service here to search for recipes using the searchTerm
    // Update the result_list with the resulted recipes
    const result: Recipe[] = this.recipe_list.filter((recipe) =>
      recipe.Name.toLowerCase().includes(keyword.toLowerCase())
    );
    const resultNames: string[] = result.map((recipe) => recipe.Name);
    //this.result_list = this.recipe_list.filter(recipe => recipe.Name.toLowerCase().includes(keyword.toLowerCase()));
    return of(result);
  }


  // Search for recipes and display them as cards
  // Search so the searchTerm is included in the recipe name (must both be turned lowercase)
  searchRecipe() {
    this.result_list = this.recipe_list.filter((recipe) =>
      recipe.Name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }


  moveToNameSearch() {
    this.router.navigate(['/name-search']);
  }

  moveToIngredientSearch() {
    this.router.navigate(['/ingredient-search']);
  }

}
