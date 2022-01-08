import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostAuthorsComponent } from './post-authors.component';

describe('PostAuthorsComponent', () => {
  let component: PostAuthorsComponent;
  let fixture: ComponentFixture<PostAuthorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostAuthorsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostAuthorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
