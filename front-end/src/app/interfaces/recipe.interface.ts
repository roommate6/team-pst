import { Ingredient } from "./ingredient.interface";

export interface Recipe {
  //Id: number;
  Name: string;
  Description: string;
  Steps: string[];
  Ingredients: Ingredient[];
  ImageURL: string;
}
