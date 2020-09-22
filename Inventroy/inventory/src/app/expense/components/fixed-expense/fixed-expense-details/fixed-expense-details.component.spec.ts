import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixedExpenseDetailsComponent } from './fixed-expense-details.component';

describe('FixedExpenseDetailsComponent', () => {
  let component: FixedExpenseDetailsComponent;
  let fixture: ComponentFixture<FixedExpenseDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixedExpenseDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixedExpenseDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
