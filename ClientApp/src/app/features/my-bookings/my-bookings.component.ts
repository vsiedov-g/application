import { Component, inject } from '@angular/core';
import { MyBookingsItemComponent } from './my-bookings-item/my-bookings-item.component';
import { BookingService } from 'src/app/core/services/booking.service';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { BookingResponse } from 'src/app/core/models/booking.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MarkdownModule } from 'ngx-markdown';

@Component({
  selector: 'app-my-bookings',
  standalone: true,
  imports: [MyBookingsItemComponent, CommonModule, FormsModule, MarkdownModule],
  templateUrl: './my-bookings.component.html',
  styleUrl: './my-bookings.component.css'
})
export class MyBookingsComponent {
  private bookingService = inject(BookingService);
  bookings$: Observable<BookingResponse[]>;
  aiResponse$: Observable<{response: string}>;
  message: string;
  question: string;
  exampleQuestions = [
    "How many bookings do i have?",
    "What do i have booked for the next week?",
    "List all my private room bookings"
  ]
  ngOnInit(){
    this.bookings$ = this.bookingService.getAll();
    this.bookingService.getAll().subscribe(res => console.log(res))
  }
  onBookingDeleted(){
    this.bookings$ = this.bookingService.getAll();
  }

  sendMessageToAI(message: string){
    if (!message.trim()){
      return;
    }
    this.aiResponse$ = this.bookingService.aiHelper(message);
    this.question = message;
    message = '';
  }
}
