import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../interfaces/recipe.interface';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from 'src/app/services/recipe.service';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss'],
})
export class RecipePageComponent implements OnInit {
  recipe!: Recipe;
  recipeImageUrl!: string;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _recipeService: RecipeService,
    private _imageService: ImageService
  ) {}

  async ngOnInit(): Promise<void> {
    const recipeId = this._activatedRoute.snapshot.paramMap.get('id');
    if (recipeId === null) {
      return;
    }

    const recipe = await this._recipeService.getRecipeById(
      Number.parseInt(recipeId)
    );
    if (recipe === null) {
      return;
    }

    this.recipe = recipe;
    this.recipeImageUrl = await this._imageService.getImageById(
      this.recipe.imageId
    );
  }
}
