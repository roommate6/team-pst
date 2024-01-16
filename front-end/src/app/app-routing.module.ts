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
import { UserPageComponent } from './components/user-page/user-page.component';
import { RecipesPresenterComponent } from './components/recipes-presenter/recipes-presenter.component';
import { AboutPageComponent } from './components/about-page/about-page.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'dashboard', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginPageComponent },
  { path: 'register', component: RegisterPageComponent },
  {
    path: 'dashboard',
    component: DashboardPageComponent,
    children: [
      {
        path: 'home',
        component: RecipesPresenterComponent,
      },
      {
        path: 'recipe/:id',
        component: RecipePageComponent,
      },
      {
        path: 'ingredient',
        component: IngredientPageComponent,
      },
      {
        path: 'name-search',
        component: SearchNamePageComponent,
      },
      {
        path: 'ingredient-search',
        component: SearchIngredientPageComponent,
      },
      {
        path: 'user',
        component: UserPageComponent,
      },
      {
        path: 'about',
        component: AboutPageComponent,
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
