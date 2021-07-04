import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInternalTransferComponent } from './add-internal-transfer.component';

describe('AddInternalTransferComponent', () => {
  let component: AddInternalTransferComponent;
  let fixture: ComponentFixture<AddInternalTransferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddInternalTransferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddInternalTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
