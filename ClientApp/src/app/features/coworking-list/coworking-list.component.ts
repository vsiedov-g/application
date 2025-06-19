import { Component, inject } from '@angular/core';
import { CoworkingItemComponent } from './coworking-item/coworking-item.component';
import { CoworkingService } from 'src/app/core/services/coworkings.service';
import { CommonModule } from '@angular/common';
import { BehaviorSubject, Observable } from 'rxjs';
import { Coworking } from 'src/app/core/models/coworking.model';

@Component({
  selector: 'app-coworking-list',
  standalone: true,
  imports: [CoworkingItemComponent, CommonModule],
  templateUrl: './coworking-list.component.html',
  styleUrl: './coworking-list.component.css'
})
export class CoworkingListComponent {
  private coworkingService = inject(CoworkingService);
  coworkings$ = new Observable<Coworking[]>;

  ngOnInit(){
    this.coworkings$ = this.coworkingService.getAll()
  }
}
