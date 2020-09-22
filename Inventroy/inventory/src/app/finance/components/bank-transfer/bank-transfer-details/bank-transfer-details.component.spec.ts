import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BankTransferDetailsComponent } from './bank-transfer-details.component';

describe('BankTransferDetailsComponent', () => {
  let component: BankTransferDetailsComponent;
  let fixture: ComponentFixture<BankTransferDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankTransferDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankTransferDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
