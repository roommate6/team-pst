import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchNamePageComponent } from './search-name-page.component';

describe('SearchNamePageComponent', () => {
  let component: SearchNamePageComponent;
  let fixture: ComponentFixture<SearchNamePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchNamePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchNamePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
