import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyLottieComponent } from './my-lottie.component';

describe('MyLottieComponent', () => {
  let component: MyLottieComponent;
  let fixture: ComponentFixture<MyLottieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyLottieComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MyLottieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
