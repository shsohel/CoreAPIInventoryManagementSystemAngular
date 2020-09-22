import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFixedExpenseSettingComponent } from './add-fixed-expense-setting.component';

describe('AddFixedExpenseSettingComponent', () => {
  let component: AddFixedExpenseSettingComponent;
  let fixture: ComponentFixture<AddFixedExpenseSettingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFixedExpenseSettingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFixedExpenseSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
