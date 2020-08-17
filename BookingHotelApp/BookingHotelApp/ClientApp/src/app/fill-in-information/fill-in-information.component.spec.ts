import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FillInInformationComponent } from './fill-in-information.component';

describe('FillInInformationComponent', () => {
  let component: FillInInformationComponent;
  let fixture: ComponentFixture<FillInInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FillInInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FillInInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
