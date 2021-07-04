import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBankTransferComponent } from './add-bank-transfer.component';

describe('AddBankTransferComponent', () => {
  let component: AddBankTransferComponent;
  let fixture: ComponentFixture<AddBankTransferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBankTransferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBankTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
