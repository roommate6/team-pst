import { Ingredient } from './ingredient.interface';

export interface Recipe {
  id: number;
  name: string;
  shortDescription: string;
  ingredients: Ingredient[];
  imageId: number;
}
