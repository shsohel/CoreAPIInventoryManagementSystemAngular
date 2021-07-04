import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalTansferListComponent } from './external-tansfer-list.component';

describe('ExternalTansferListComponent', () => {
  let component: ExternalTansferListComponent;
  let fixture: ComponentFixture<ExternalTansferListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExternalTansferListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalTansferListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
