import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { StepCardComponent } from './step-card/step-card.component';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { IngredientPageComponent } from './ingredient-page/ingredient-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';


const routes: Routes = [
  {path : '',redirectTo:'login', pathMatch: 'full'},
  {path : 'login', component: LoginPageComponent},
  {path : 'register', component: RegisterPageComponent},
  {path : 'recipe', component: RecipePageComponent},
  {path : 'ingredient', component: IngredientPageComponent},
  {path : 'menu', component: SideMenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
