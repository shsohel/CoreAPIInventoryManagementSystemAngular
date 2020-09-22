import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryPaymentDetailsComponent } from './salary-payment-details.component';

describe('SalaryPaymentDetailsComponent', () => {
  let component: SalaryPaymentDetailsComponent;
  let fixture: ComponentFixture<SalaryPaymentDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaryPaymentDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaryPaymentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
