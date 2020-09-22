import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralExpenseListComponent } from './general-expense-list.component';

describe('GeneralExpenseListComponent', () => {
  let component: GeneralExpenseListComponent;
  let fixture: ComponentFixture<GeneralExpenseListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeneralExpenseListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneralExpenseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
