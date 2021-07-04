import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseHeadDetailsComponent } from './expense-head-details.component';

describe('ExpenseHeadDetailsComponent', () => {
  let component: ExpenseHeadDetailsComponent;
  let fixture: ComponentFixture<ExpenseHeadDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpenseHeadDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpenseHeadDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
