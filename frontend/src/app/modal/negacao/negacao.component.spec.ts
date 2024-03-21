import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NegacaoComponent } from './negacao.component';

describe('NegacaoComponent', () => {
  let component: NegacaoComponent;
  let fixture: ComponentFixture<NegacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NegacaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NegacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
