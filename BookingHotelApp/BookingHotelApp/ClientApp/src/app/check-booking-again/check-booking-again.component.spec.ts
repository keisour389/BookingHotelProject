import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckBookingAgainComponent } from './check-booking-again.component';

describe('CheckBookingAgainComponent', () => {
  let component: CheckBookingAgainComponent;
  let fixture: ComponentFixture<CheckBookingAgainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckBookingAgainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckBookingAgainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
