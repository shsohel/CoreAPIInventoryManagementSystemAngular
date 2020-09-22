import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBusinessRelativeComponent } from './add-business-relative.component';

describe('AddBusinessRelativeComponent', () => {
  let component: AddBusinessRelativeComponent;
  let fixture: ComponentFixture<AddBusinessRelativeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBusinessRelativeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBusinessRelativeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
