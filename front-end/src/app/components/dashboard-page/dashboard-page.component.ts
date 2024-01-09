import { Component } from '@angular/core';
import recipeData from '../../services/recipes.json';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent {
    //List of recipes
    public recipe_list = recipeData;
}
