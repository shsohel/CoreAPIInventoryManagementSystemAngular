import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FixedExpenseSettingListComponent } from './fixed-expense-setting-list.component';

describe('FixedExpenseSettingListComponent', () => {
  let component: FixedExpenseSettingListComponent;
  let fixture: ComponentFixture<FixedExpenseSettingListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FixedExpenseSettingListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FixedExpenseSettingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
