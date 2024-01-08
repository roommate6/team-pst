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

import { User } from './interfaces/user.interface';

import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzCardModule } from 'ng-zorro-antd/card';
import {
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterPageComponent } from './register-page/register-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { NzListModule } from 'ng-zorro-antd/list';
import { RecipeCardComponent } from './recipe-card/recipe-card.component';


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
    RegisterPageComponent
    SearchPageComponent,
    RecipeCardComponent
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
    ReactiveFormsModule,
    NzListModule,
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent],
})
export class AppModule {}
