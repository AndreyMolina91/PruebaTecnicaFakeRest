import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorsByBookComponent } from './authors-by-book.component';

describe('AuthorsByBookComponent', () => {
  let component: AuthorsByBookComponent;
  let fixture: ComponentFixture<AuthorsByBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorsByBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthorsByBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
