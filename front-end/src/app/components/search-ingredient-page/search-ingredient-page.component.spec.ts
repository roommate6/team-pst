import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchIngredientPageComponent } from './search-ingredient-page.component';

describe('SearchIngredientPageComponent', () => {
  let component: SearchIngredientPageComponent;
  let fixture: ComponentFixture<SearchIngredientPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchIngredientPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchIngredientPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
