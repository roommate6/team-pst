import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { debounce, interval, of, switchMap, tap } from 'rxjs';
import recipeData from '../../services/recipes.json';

@Component({
  selector: 'app-search-name-page',
  templateUrl: './search-name-page.component.html',
  styleUrls: ['./search-name-page.component.scss'],
})
export class SearchNamePageComponent {
  searchTerm = '';
  searchWord: FormControl = new FormControl();

  public recipe_list: Recipe[] = recipeData;
  public result_list: Recipe[] = [];
  isLoading = false;

  //List of the cards with the steps
  recipeCardList: RecipeCardComponent[] = [];
  recipeCard: RecipeCardComponent = new RecipeCardComponent();

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

  constructor() {
    this.createCardList();
  }

  /**/
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

  createCardList() {
    // Create the list of cards with the steps
    //this.stepCardList = this.result_list.map(recipe => new StepCardComponent(recipe));
    for (let i = 0; i < this.recipe_list.length; i++) {
      this.recipeCard = new RecipeCardComponent();
      this.recipeCard.recipeName = this.recipe_list[i].Name;
      this.recipeCard.recipeDescription = this.recipe_list[i].Description;
      this.recipeCard.recipeImageUrl = this.recipe_list[i].ImageURL;
    }
  }
}
