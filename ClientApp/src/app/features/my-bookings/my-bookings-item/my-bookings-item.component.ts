import { DatePipe } from '@angular/common';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BookingResponse } from 'src/app/core/models/booking.model';
import { AlertService } from 'src/app/core/services/alert.service';
import { BookingService } from 'src/app/core/services/booking.service';

@Component({
  selector: 'app-my-bookings-item',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './my-bookings-item.component.html',
  styleUrl: './my-bookings-item.component.css'
})
export class MyBookingsItemComponent {
  @Input() booking: BookingResponse;
  @Output() bookingDeleted = new EventEmitter<number>();
  private router = inject(Router);
  private bookingService = inject(BookingService);
  private alertService = inject(AlertService);
  dummyDate = '1970-01-01T';
  ngOnInit(){
    console.log(this.booking)
  }
  onEditBooking() {
    this.router.navigate(['/booking', this.booking.id]);
  }
  onDeleteBooking() {
    this.alertService.confirm("This action cannot be undone","Cancel your booking?").then(result => {
      if(result.isConfirmed) {
        this.bookingService.delete(this.booking.id).subscribe({next: () => {
          this.alertService.success('Booking was successfully deleted.');
          this.bookingDeleted.emit(this.booking.id);
        }, error: () => {
          this.alertService.error('There was an error deleting the booking.');
          }
      });
      }
    })
  }
}
