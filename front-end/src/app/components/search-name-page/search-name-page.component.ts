import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { debounce, interval, of, switchMap, tap } from 'rxjs';
import recipeData from '../../services/recipes.json';
import { Route, Router } from '@angular/router';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-search-name-page',
  templateUrl: './search-name-page.component.html',
  styleUrls: ['./search-name-page.component.scss'],
})
export class SearchNamePageComponent {
  searchTerm = '';
  searchWord: FormControl = new FormControl();

  public recipeList: Recipe[] = recipeData;
  public result_list: Recipe[] = [];
  isLoading = false;

  recipeCardList: RecipeCardComponent[] = [];
  router: Router;

  constructor(router: Router, private _recipeService: RecipeService) {
    this.router = router;
  }

  async ngOnInit(): Promise<void> {
    this.recipeList = await this._recipeService.getAllRecipes();
    this.result_list = this.recipeList;
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

  searchRecipes(keyword: string) {
    const result: Recipe[] = this.recipeList.filter((recipe) =>
      recipe.name.toLowerCase().includes(keyword.toLowerCase())
    );
    return of(result);
  }

  searchRecipe() {
    this.result_list = this.recipeList.filter((recipe) =>
      recipe.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  moveToNameSearch() {
    this.router.navigate(['/name-search']);
  }

  moveToIngredientSearch() {
    this.router.navigate(['/ingredient-search']);
  }
}
