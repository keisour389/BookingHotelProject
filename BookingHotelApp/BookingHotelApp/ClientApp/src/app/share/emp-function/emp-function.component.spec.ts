import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpFunctionComponent } from './emp-function.component';

describe('EmpFunctionComponent', () => {
  let component: EmpFunctionComponent;
  let fixture: ComponentFixture<EmpFunctionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmpFunctionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpFunctionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
