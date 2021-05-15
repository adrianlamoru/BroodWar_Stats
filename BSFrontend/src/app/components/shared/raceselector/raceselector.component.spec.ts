import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RaceselectorComponent } from './raceselector.component';

describe('RaceselectorComponent', () => {
  let component: RaceselectorComponent;
  let fixture: ComponentFixture<RaceselectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaceselectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaceselectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
