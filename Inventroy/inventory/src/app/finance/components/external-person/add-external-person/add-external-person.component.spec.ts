import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddExternalPersonComponent } from './add-external-person.component';

describe('AddExternalPersonComponent', () => {
  let component: AddExternalPersonComponent;
  let fixture: ComponentFixture<AddExternalPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddExternalPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddExternalPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
