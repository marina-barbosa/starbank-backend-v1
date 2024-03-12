import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AnimationItem } from 'lottie-web';
import { LottieDirective, AnimationOptions, LottieComponent } from 'ngx-lottie';
import { timer } from 'rxjs/internal/observable/timer';

@Component({
  selector: 'app-my-lottie',
  standalone: true,
  imports: [LottieDirective, LottieComponent, RouterLink],
  templateUrl: './my-lottie.component.html',
  styleUrl: './my-lottie.component.scss'
})
export class MyLottieComponent implements OnInit {
  options: AnimationOptions = {
    path: '/assets/lottie.json',
  };

  animationFinished = false;

  constructor(private router: Router) { }

  ngOnInit() { }

  animationCreated(animationItem: AnimationItem): void {
    console.log(animationItem);
    timer(3500).subscribe(() => this.router.navigate(['/tour']));

  }
}
