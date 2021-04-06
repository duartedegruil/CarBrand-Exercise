import { TestBed } from '@angular/core/testing';

import { CarbrandService } from './carbrand.service';

describe('CarbrandService', () => {
  let service: CarbrandService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarbrandService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
