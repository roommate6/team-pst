import { RecipePageComponent } from './components/recipe-page/recipe-page.component';
import { SearchPageComponent } from './components/search-page/search-page.component';
import { StepCardComponent } from './components/step-card/step-card.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { IngredientPageComponent } from './components/ingredient-page/ingredient-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {path : '',redirectTo:'login', pathMatch: 'full'},
  {path : 'name-search', component: SearchPageComponent},
  {path : 'login', component: LoginPageComponent},
  {path : 'register', component: RegisterPageComponent},
  {path : 'recipe', component: RecipePageComponent},
  {path : 'ingredient', component: IngredientPageComponent},
  {path : 'menu', component: SideMenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
