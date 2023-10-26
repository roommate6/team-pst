import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { IngredientPageComponent } from './ingredient-page/ingredient-page.component';

@NgModule({
  declarations: [
    AppComponent,
    RecipePageComponent,
    IngredientPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
