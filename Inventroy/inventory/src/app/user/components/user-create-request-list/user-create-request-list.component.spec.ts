import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCreateRequestListComponent } from './user-create-request-list.component';

describe('UserCreateRequestListComponent', () => {
  let component: UserCreateRequestListComponent;
  let fixture: ComponentFixture<UserCreateRequestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserCreateRequestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCreateRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
