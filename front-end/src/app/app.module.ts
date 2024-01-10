import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecipePageComponent } from './components/recipe-page/recipe-page.component';
import { IngredientPageComponent } from './components/ingredient-page/ingredient-page.component';
import { StepCardComponent } from './components/step-card/step-card.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IngredientListComponent } from './components/ingredient-list/ingredient-list.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { LoginPageComponent } from './components/login-page/login-page.component';

import { Injector } from '@angular/core';

import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzListModule } from 'ng-zorro-antd/list';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { Router } from '@angular/router';
import { DashboardPageComponent } from './components/dashboard-page/dashboard-page.component';
import { RecipeCardComponent } from './components/recipe-card/recipe-card.component';
import { SearchNamePageComponent } from './components/search-name-page/search-name-page.component';
import { SearchIngredientPageComponent } from './components/search-ingredient-page/search-ingredient-page.component';
import { UserPageComponent } from './components/user-page/user-page.component';

export let AppInjector: Injector;

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    RecipePageComponent,
    IngredientPageComponent,
    StepCardComponent,
    IngredientListComponent,
    SideMenuComponent,
    LoginPageComponent,
    RegisterPageComponent,
    DashboardPageComponent,
    RecipeCardComponent,
    SearchNamePageComponent,
    SearchIngredientPageComponent,
    UserPageComponent,
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
    NzFormModule,
    NzInputModule,
    NzCardModule,
    NzListModule,
    ReactiveFormsModule,
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(private injector: Injector, private router: Router) {
    AppInjector = this.injector;
  }
}
