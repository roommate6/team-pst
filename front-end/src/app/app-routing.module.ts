import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { StepCardComponent } from './step-card/step-card.component';
import { SideMenuComponent } from './side-menu/side-menu.component';


const routes: Routes = [
  { path: '', component: RecipePageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
