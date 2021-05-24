import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewUsersComponent } from './addnew-users.component';

describe('AddnewUsersComponent', () => {
  let component: AddnewUsersComponent;
  let fixture: ComponentFixture<AddnewUsersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddnewUsersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddnewUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
