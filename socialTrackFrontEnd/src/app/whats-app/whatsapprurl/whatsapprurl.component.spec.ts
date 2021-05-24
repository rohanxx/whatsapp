import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatsapprurlComponent } from './whatsapprurl.component';

describe('WhatsapprurlComponent', () => {
  let component: WhatsapprurlComponent;
  let fixture: ComponentFixture<WhatsapprurlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhatsapprurlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhatsapprurlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
