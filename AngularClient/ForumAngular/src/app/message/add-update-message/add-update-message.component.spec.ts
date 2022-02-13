import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateMessageComponent } from './add-update-message.component';

describe('AddUpdateMessageComponent', () => {
  let component: AddUpdateMessageComponent;
  let fixture: ComponentFixture<AddUpdateMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateMessageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
