import { Ingredient } from './ingredient';

export class Recipe {
  id!: number;
  name!: string;
  shortDescription!: string;
  ingredients: Ingredient[] = [];
  imageId?: number;
}
