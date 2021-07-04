import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralExpenseDetailsComponent } from './general-expense-details.component';

describe('GeneralExpenseDetailsComponent', () => {
  let component: GeneralExpenseDetailsComponent;
  let fixture: ComponentFixture<GeneralExpenseDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeneralExpenseDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneralExpenseDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
