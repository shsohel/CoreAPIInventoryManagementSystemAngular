import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCreateRequestComponent } from './user-create-request.component';

describe('UserCreateRequestComponent', () => {
  let component: UserCreateRequestComponent;
  let fixture: ComponentFixture<UserCreateRequestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserCreateRequestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCreateRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
