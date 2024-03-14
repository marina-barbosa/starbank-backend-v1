import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalTourComponent } from './modal-tour.component';

describe('ModalTourComponent', () => {
  let component: ModalTourComponent;
  let fixture: ComponentFixture<ModalTourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalTourComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalTourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
