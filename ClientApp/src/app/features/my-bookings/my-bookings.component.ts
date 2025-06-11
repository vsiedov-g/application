import { Component, inject } from '@angular/core';
import { MyBookingsItemComponent } from './my-bookings-item/my-bookings-item.component';
import { BookingService } from 'src/app/core/services/booking.service';
import { Observable } from 'rxjs';
import { BookingResponse } from 'src/app/core/models/booking.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-my-bookings',
  standalone: true,
  imports: [MyBookingsItemComponent, CommonModule],
  templateUrl: './my-bookings.component.html',
  styleUrl: './my-bookings.component.css'
})
export class MyBookingsComponent {
  private bookingService = inject(BookingService);
  bookings$: Observable<BookingResponse[]>;
  ngOnInit(){
    this.bookings$ = this.bookingService.getAll();
    this.bookingService.getAll().subscribe(res => console.log(res))
  }
  onBookingDeleted(){
    this.bookings$ = this.bookingService.getAll();
  }
}
