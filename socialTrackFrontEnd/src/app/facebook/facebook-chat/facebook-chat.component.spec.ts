import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacebookChatComponent } from './facebook-chat.component';

describe('FacebookChatComponent', () => {
  let component: FacebookChatComponent;
  let fixture: ComponentFixture<FacebookChatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacebookChatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacebookChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
