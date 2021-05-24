import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminComComponent } from './admin-com.component';

describe('AdminComComponent', () => {
  let component: AdminComComponent;
  let fixture: ComponentFixture<AdminComComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminComComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminComComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
