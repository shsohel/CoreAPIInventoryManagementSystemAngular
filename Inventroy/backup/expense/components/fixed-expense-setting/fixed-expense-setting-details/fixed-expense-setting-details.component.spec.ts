import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixedExpenseSettingDetailsComponent } from './fixed-expense-setting-details.component';

describe('FixedExpenseSettingDetailsComponent', () => {
  let component: FixedExpenseSettingDetailsComponent;
  let fixture: ComponentFixture<FixedExpenseSettingDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixedExpenseSettingDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixedExpenseSettingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
