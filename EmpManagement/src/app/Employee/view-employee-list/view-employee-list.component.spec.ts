import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEmployeeListComponent } from './view-employee-list.component';

describe('ViewEmployeeListComponent', () => {
  let component: ViewEmployeeListComponent;
  let fixture: ComponentFixture<ViewEmployeeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewEmployeeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEmployeeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
