import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppMatDialogComponent } from './app-mat-dialog.component';

describe('AppMatDialogComponent', () => {
  let component: AppMatDialogComponent;
  let fixture: ComponentFixture<AppMatDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppMatDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppMatDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
