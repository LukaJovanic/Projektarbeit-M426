import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MotorradUebersichtComponent } from './motorrad-uebersicht.component';

describe('MotorradUebersichtComponent', () => {
  let component: MotorradUebersichtComponent;
  let fixture: ComponentFixture<MotorradUebersichtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MotorradUebersichtComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MotorradUebersichtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
