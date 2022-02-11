import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateTopicComponent } from './add-update-topic.component';

describe('AddUpdateTopicComponent', () => {
  let component: AddUpdateTopicComponent;
  let fixture: ComponentFixture<AddUpdateTopicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateTopicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateTopicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
