import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { IngredientPageComponent } from './ingredient-page/ingredient-page.component';
import { StepCardComponent } from './step-card/step-card.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { SideMenuComponent } from './side-menu/side-menu.component';

import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    RecipePageComponent,
    IngredientPageComponent,
    StepCardComponent,
    IngredientListComponent,
    SideMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,

    NzButtonModule,
    NzIconModule,
    NzMenuModule,
    NzLayoutModule,
    NzBreadCrumbModule,
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
