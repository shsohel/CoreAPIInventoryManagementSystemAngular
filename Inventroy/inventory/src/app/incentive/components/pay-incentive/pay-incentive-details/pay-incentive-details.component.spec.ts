import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PayIncentiveDetailsComponent } from './pay-incentive-details.component';

describe('PayIncentiveDetailsComponent', () => {
  let component: PayIncentiveDetailsComponent;
  let fixture: ComponentFixture<PayIncentiveDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PayIncentiveDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PayIncentiveDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
