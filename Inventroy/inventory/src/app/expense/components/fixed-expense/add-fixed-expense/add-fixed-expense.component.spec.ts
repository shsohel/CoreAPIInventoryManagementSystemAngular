import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFixedExpenseComponent } from './add-fixed-expense.component';

describe('AddFixedExpenseComponent', () => {
  let component: AddFixedExpenseComponent;
  let fixture: ComponentFixture<AddFixedExpenseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFixedExpenseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFixedExpenseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
