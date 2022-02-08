import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateSectionComponent } from './add-update-section.component';

describe('AddUpdateSectionComponent', () => {
  let component: AddUpdateSectionComponent;
  let fixture: ComponentFixture<AddUpdateSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
