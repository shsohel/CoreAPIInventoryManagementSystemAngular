import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGeneralExpenseComponent } from './add-general-expense.component';

describe('AddGeneralExpenseComponent', () => {
  let component: AddGeneralExpenseComponent;
  let fixture: ComponentFixture<AddGeneralExpenseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddGeneralExpenseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGeneralExpenseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
