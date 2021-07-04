import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddExternalTansferComponent } from './add-external-tansfer.component';

describe('AddExternalTansferComponent', () => {
  let component: AddExternalTansferComponent;
  let fixture: ComponentFixture<AddExternalTansferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddExternalTansferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddExternalTansferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
