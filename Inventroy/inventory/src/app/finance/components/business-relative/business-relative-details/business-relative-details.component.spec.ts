import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessRelativeDetailsComponent } from './business-relative-details.component';

describe('BusinessRelativeDetailsComponent', () => {
  let component: BusinessRelativeDetailsComponent;
  let fixture: ComponentFixture<BusinessRelativeDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessRelativeDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessRelativeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
