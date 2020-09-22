import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalTansferListComponent } from './internal-tansfer-list.component';

describe('InternalTansferListComponent', () => {
  let component: InternalTansferListComponent;
  let fixture: ComponentFixture<InternalTansferListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalTansferListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalTansferListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
