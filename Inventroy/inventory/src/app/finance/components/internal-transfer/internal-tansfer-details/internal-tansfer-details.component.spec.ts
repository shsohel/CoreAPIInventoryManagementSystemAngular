import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalTansferDetailsComponent } from './internal-tansfer-details.component';

describe('InternalTansferDetailsComponent', () => {
  let component: InternalTansferDetailsComponent;
  let fixture: ComponentFixture<InternalTansferDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalTansferDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalTansferDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
