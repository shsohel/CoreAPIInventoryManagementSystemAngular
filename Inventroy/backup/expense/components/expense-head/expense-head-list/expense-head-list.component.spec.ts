import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseHeadListComponent } from './expense-head-list.component';

describe('ExpenseHeadListComponent', () => {
  let component: ExpenseHeadListComponent;
  let fixture: ComponentFixture<ExpenseHeadListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpenseHeadListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpenseHeadListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
