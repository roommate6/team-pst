export class ApiConfigurations {
  // API BASE URL

  readonly apiBaseUrl: string = 'https://localhost:7223/api/';

  // CONTROLLERS BASE URLS

  readonly authenticationBaseUrl: string = this.apiBaseUrl + 'Authentication/';
  readonly ingredientBaseUrl: string = this.apiBaseUrl + 'Ingredient/';
  readonly recipeBaseUrl: string = this.apiBaseUrl + 'Recipe/';

  // AUTHENTICATION URLS

  // post
  readonly authenticationLoginUrl: string =
    this.authenticationBaseUrl + 'login';
  // post
  readonly authenticationRegisterUrl: string =
    this.authenticationBaseUrl + 'register';

  // INGREDIENT URLS

  // get
  readonly ingredientAllUrl: string = this.ingredientBaseUrl + 'all';
  // post
  readonly ingredientAddUrl: string = this.ingredientBaseUrl + 'add';

  // RECIPE URLS

  // get
  readonly recipeAllUrl: string = this.recipeBaseUrl + 'all';
  // get
  readonly recipeAllByIngredientsUrl: string =
    this.recipeBaseUrl + 'all-by-ingredients';
  // post
  readonly recipeAddUrl: string = this.recipeBaseUrl + 'add';
  // post
  readonly recipeAddIngredientUrl: string =
    this.recipeBaseUrl + 'add-ingredient';

  static get instance(): ApiConfigurations {
    if (ApiConfigurations._instance === null) {
      ApiConfigurations._instance = new ApiConfigurations();
    }
    return ApiConfigurations._instance;
  }

  private constructor() {
    console.log('singleton initialized');
  }

  private static _instance: ApiConfigurations | null = null;
}
