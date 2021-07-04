import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalPersonDetailsComponent } from './external-person-details.component';

describe('ExternalPersonDetailsComponent', () => {
  let component: ExternalPersonDetailsComponent;
  let fixture: ComponentFixture<ExternalPersonDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExternalPersonDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalPersonDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
