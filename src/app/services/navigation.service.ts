import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  private selectedComponentSource = new BehaviorSubject<string>('central');
  selectedComponent$ = this.selectedComponentSource.asObservable();

  constructor() { }

  changeSelectedComponent(component: string) {
    this.selectedComponentSource.next(component);
  }
}
