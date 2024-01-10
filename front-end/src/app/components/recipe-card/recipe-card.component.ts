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
    const imageArrayBuffer = await this._imageService.getImageById(
      this.recipe.imageId
    );

    if (imageArrayBuffer === null || imageArrayBuffer === undefined) {
      this.imageUrl = '/assets/missing_image_placeholder.jpg';
      return;
    }

    if (typeof imageArrayBuffer === 'string') {
      this.imageUrl = imageArrayBuffer;
    }

    const blob = new Blob([imageArrayBuffer], { type: 'image/jpg' });
    this.imageUrl = URL.createObjectURL(blob);
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
