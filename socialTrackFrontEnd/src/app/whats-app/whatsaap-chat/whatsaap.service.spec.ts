import { TestBed } from '@angular/core/testing';

import { WhatsaapService } from './whatsaap.service';

describe('WhatsaapService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WhatsaapService = TestBed.get(WhatsaapService);
    expect(service).toBeTruthy();
  });
});
