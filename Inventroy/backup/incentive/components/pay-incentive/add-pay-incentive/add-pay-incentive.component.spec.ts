import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPayIncentiveComponent } from './add-pay-incentive.component';

describe('AddPayIncentiveComponent', () => {
  let component: AddPayIncentiveComponent;
  let fixture: ComponentFixture<AddPayIncentiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPayIncentiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPayIncentiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
