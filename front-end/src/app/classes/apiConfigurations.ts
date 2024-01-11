export class ApiConfigurations {
  // API BASE URL

  readonly apiBaseUrl: string = 'https://localhost:7223/api';

  // CONTROLLERS BASE URLS

  readonly authenticationBaseUrl: string = this.apiBaseUrl + '/Authentication';
  readonly ingredientBaseUrl: string = this.apiBaseUrl + '/Ingredient';
  readonly recipeBaseUrl: string = this.apiBaseUrl + '/Recipe';
  readonly imageBaseUrl: string = this.apiBaseUrl + '/Images';

  // AUTHENTICATION URLS

  // post
  readonly authenticationLoginUrl: string =
    this.authenticationBaseUrl + '/login';
  // post
  readonly authenticationRegisterUrl: string =
    this.authenticationBaseUrl + '/register';

  // INGREDIENT URLS

  // get
  readonly ingredientAllUrl: string = this.ingredientBaseUrl + '/all';
  // post
  readonly ingredientAddUrl: string = this.ingredientBaseUrl + '/add';

  // RECIPE URLS

  // get
  readonly recipeGetUrl: string = this.recipeBaseUrl;
  // get
  readonly recipeAllUrl: string = this.recipeBaseUrl + '/all';
  // get
  readonly recipeAllByIngredientsIdsUrl: string =
    this.recipeBaseUrl + '/all-by-ingredients-ids';
  // get
  readonly recipeAllByIngredientsIdsExclusiveUrl: string =
    this.recipeBaseUrl + '/all-by-ingredients-ids-exclusive';
  // get
  readonly recipeAllByIngredientsNamesUrl: string =
    this.recipeBaseUrl + '/all-by-ingredients-names';
  // post
  readonly recipeAddUrl: string = this.recipeBaseUrl + '/add';
  // post
  readonly recipeAddIngredientUrl: string =
    this.recipeBaseUrl + '/add-ingredient';

  // IMAGE URLS

  // get
  readonly imageGetUrl: string = this.imageBaseUrl;

  static get instance(): ApiConfigurations {
    if (ApiConfigurations._instance === null) {
      ApiConfigurations._instance = new ApiConfigurations();
    }
    return ApiConfigurations._instance;
  }

  private constructor() {}

  private static _instance: ApiConfigurations | null = null;
}
