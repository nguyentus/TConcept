import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SofaDetailComponent } from './sofa-detail.component';

describe('SofaDetailComponent', () => {
  let component: SofaDetailComponent;
  let fixture: ComponentFixture<SofaDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SofaDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SofaDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
