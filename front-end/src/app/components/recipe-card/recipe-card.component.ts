import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../interfaces/recipe.interface';
import { ImageService } from 'src/app/services/image.service';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss'],
})
export class RecipeCardComponent implements OnInit {
  @Input() recipe!: Recipe;

  imageUrl!: string;

  constructor(
    private _imageService: ImageService,
    private _eventBusService: EventBusService
  ) {}

  async ngOnInit(): Promise<void> {
    this.imageUrl = await this._imageService.getImageById(this.recipe.imageId);
  }

  onRecipeClick() {
    this._eventBusService.publish({
      name: 'DASHBOARD_view_recipe_button_click_event',
      carryingData: {
        recipeId: this.recipe.id,
      },
    });
  }
}
