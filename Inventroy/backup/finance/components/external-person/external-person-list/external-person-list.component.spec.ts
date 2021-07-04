import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalPersonListComponent } from './external-person-list.component';

describe('ExternalPersonListComponent', () => {
  let component: ExternalPersonListComponent;
  let fixture: ComponentFixture<ExternalPersonListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExternalPersonListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExternalPersonListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
