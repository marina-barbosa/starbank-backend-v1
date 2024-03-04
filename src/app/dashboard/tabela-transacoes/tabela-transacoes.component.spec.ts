import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabelaTransacoesComponent } from './tabela-transacoes.component';

describe('TabelaTransacoesComponent', () => {
  let component: TabelaTransacoesComponent;
  let fixture: ComponentFixture<TabelaTransacoesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TabelaTransacoesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TabelaTransacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
