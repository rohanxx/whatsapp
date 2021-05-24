import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatsaapChatComponent } from './whatsaap-chat.component';

describe('WhatsaapChatComponent', () => {
  let component: WhatsaapChatComponent;
  let fixture: ComponentFixture<WhatsaapChatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhatsaapChatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhatsaapChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
