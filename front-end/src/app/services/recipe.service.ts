import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe } from '../interfaces/recipe.interface';
import { ApiConfigurations } from '../classes/apiConfigurations';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  constructor(private _http: HttpClient) {}

  async getAllRecipes(): Promise<Recipe[]> {
    const appropriateUrl: string = ApiConfigurations.instance.recipeAllUrl;
    const headers = new HttpHeaders({});

    try {
      const result = await firstValueFrom(
        this._http.get<Recipe[]>(appropriateUrl, { headers: headers }),
        { defaultValue: [] }
      );
      return result;
    } catch (error) {
      console.error('Error fetching recipes:', error);
      return [];
    }
  }

  async getRecipeById(id: number): Promise<Recipe | null> {
    const appropriateUrl = ApiConfigurations.instance.recipeGetUrl + `/${id}`;
    const headers = new HttpHeaders({});

    try {
      const result = await firstValueFrom(
        this._http.get<Recipe>(appropriateUrl, { headers: headers }),
        { defaultValue: null }
      );
      return result;
    } catch (error) {
      console.error('Error fetching recipe:', error);
      return null;
    }
  }
}
