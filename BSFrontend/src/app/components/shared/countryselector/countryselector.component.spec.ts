import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryselectorComponent } from './countryselector.component';

describe('CountryselectorComponent', () => {
  let component: CountryselectorComponent;
  let fixture: ComponentFixture<CountryselectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryselectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryselectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
