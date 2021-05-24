import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstagramChatComponent } from './instagram-chat.component';

describe('InstagramChatComponent', () => {
  let component: InstagramChatComponent;
  let fixture: ComponentFixture<InstagramChatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstagramChatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstagramChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
