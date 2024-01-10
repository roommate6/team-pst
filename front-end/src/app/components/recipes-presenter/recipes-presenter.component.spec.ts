import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipesPresenterComponent } from './recipes-presenter.component';

describe('RecipesPresenterComponent', () => {
  let component: RecipesPresenterComponent;
  let fixture: ComponentFixture<RecipesPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipesPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecipesPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
