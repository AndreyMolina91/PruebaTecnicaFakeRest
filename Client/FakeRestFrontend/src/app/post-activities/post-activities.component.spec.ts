import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostActivitiesComponent } from './post-activities.component';

describe('PostActivitiesComponent', () => {
  let component: PostActivitiesComponent;
  let fixture: ComponentFixture<PostActivitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostActivitiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostActivitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
