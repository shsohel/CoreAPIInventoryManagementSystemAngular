import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalTansferDetailsComponent } from './external-tansfer-details.component';

describe('ExternalTansferDetailsComponent', () => {
  let component: ExternalTansferDetailsComponent;
  let fixture: ComponentFixture<ExternalTansferDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExternalTansferDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalTansferDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
