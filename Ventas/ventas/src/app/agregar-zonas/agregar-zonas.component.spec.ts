import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarZonasComponent } from './agregar-zonas.component';

describe('AgregarZonasComponent', () => {
  let component: AgregarZonasComponent;
  let fixture: ComponentFixture<AgregarZonasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarZonasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarZonasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
