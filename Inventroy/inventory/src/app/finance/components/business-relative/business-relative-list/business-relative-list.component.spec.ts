import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessRelativeListComponent } from './business-relative-list.component';

describe('BusinessRelativeListComponent', () => {
  let component: BusinessRelativeListComponent;
  let fixture: ComponentFixture<BusinessRelativeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusinessRelativeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessRelativeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
