import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarVendedoresComponent } from './agregar-vendedores.component';

describe('AgregarVendedoresComponent', () => {
  let component: AgregarVendedoresComponent;
  let fixture: ComponentFixture<AgregarVendedoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarVendedoresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarVendedoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
