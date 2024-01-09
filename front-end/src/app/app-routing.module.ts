import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipePageComponent } from './components/recipe-page/recipe-page.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { IngredientPageComponent } from './components/ingredient-page/ingredient-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { DashboardPageComponent } from './components/dashboard-page/dashboard-page.component';
import { SearchNamePageComponent } from './components/search-name-page/search-name-page.component';
import { SearchIngredientPageComponent } from './components/search-ingredient-page/search-ingredient-page.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginPageComponent },
  { path: 'register', component: RegisterPageComponent },
  { path: 'dashboard', component: DashboardPageComponent },
  { path: 'recipe', component: RecipePageComponent },
  { path: 'ingredient', component: IngredientPageComponent },
  { path: 'name-search', component: SearchNamePageComponent },
  { path: 'ingredient-search', component: SearchIngredientPageComponent },
  { path: 'menu', component: SideMenuComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
