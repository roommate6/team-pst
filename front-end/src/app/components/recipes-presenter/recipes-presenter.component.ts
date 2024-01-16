import { Component } from '@angular/core';
import { Recipe } from 'src/app/interfaces/recipe.interface';
import { ImageService } from 'src/app/services/image.service';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-recipes-presenter',
  templateUrl: './recipes-presenter.component.html',
  styleUrls: ['./recipes-presenter.component.scss'],
})
export class RecipesPresenterComponent {
  recipeList!: Recipe[];
  imageUrls: string[] = [];

  constructor(private _recipeService: RecipeService, private _imageService: ImageService) {}

  async ngOnInit(): Promise<void> {
    this.recipeList = await this._recipeService.getAllRecipes();
    for (const recipe of this.recipeList) {
      this.imageUrls.push(await this.getRecipeImageUrl(recipe));
    }
  }

  async getRecipeImageUrl(recipe: Recipe): Promise<string> {
    return await this._imageService.getImageById(recipe.id);
  }
}
