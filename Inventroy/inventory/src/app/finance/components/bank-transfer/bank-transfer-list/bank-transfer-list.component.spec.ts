import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BankTransferListComponent } from './bank-transfer-list.component';

describe('BankTransferListComponent', () => {
  let component: BankTransferListComponent;
  let fixture: ComponentFixture<BankTransferListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankTransferListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankTransferListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
