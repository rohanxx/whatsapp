import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeshbordComponent } from './deshbord.component';

describe('DeshbordComponent', () => {
  let component: DeshbordComponent;
  let fixture: ComponentFixture<DeshbordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeshbordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeshbordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
