import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PayIncentiveListComponent } from './pay-incentive-list.component';

describe('PayIncentiveListComponent', () => {
  let component: PayIncentiveListComponent;
  let fixture: ComponentFixture<PayIncentiveListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PayIncentiveListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PayIncentiveListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
