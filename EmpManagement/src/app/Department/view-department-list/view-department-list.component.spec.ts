import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDepartmentListComponent } from './view-department-list.component';

describe('ViewDepartmentListComponent', () => {
  let component: ViewDepartmentListComponent;
  let fixture: ComponentFixture<ViewDepartmentListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewDepartmentListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDepartmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
