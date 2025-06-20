import { CommonModule } from '@angular/common';
import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { map, Observable, of, switchMap, tap } from 'rxjs';
import { BookingRequest, BookingResponse } from 'src/app/core/models/booking.model';
import { WorkspaceType } from 'src/app/core/models/workspace-type.model';
import { Workspace } from 'src/app/core/models/workspace.model';
import { BookingService } from 'src/app/core/services/booking.service';
import { WorkspaceTypeService } from 'src/app/core/services/workspace-type.service';
import { WorkspaceService } from 'src/app/core/services/workspace.service';
import flatpickr from 'flatpickr';
import { bookingDateValidator } from 'src/app/core/validators/booking-date.validators';
import { AlertService } from 'src/app/core/services/alert.service';
import { Coworking } from 'src/app/core/models/coworking.model';
import { CoworkingService } from 'src/app/core/services/coworkings.service';


@Component({
  selector: 'app-booking-page',
  standalone: true,
  imports: [CommonModule, 
    ReactiveFormsModule, 
    RouterModule],
  templateUrl: './booking-page.component.html',
  styleUrl: './booking-page.component.css'
})
export class BookingPageComponent {
  @ViewChild('startDateInput') startDateInput!: ElementRef;
  @ViewChild('endDateInput') endDateInput!: ElementRef;
  @ViewChild('startTimeInput') startTimeInput!: ElementRef;
  @ViewChild('endTimeInput') endTimeInput!: ElementRef;

  private coworkingService = inject(CoworkingService);
  private workspaceService = inject(WorkspaceService);
  private bookingService = inject(BookingService);
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private alertService = inject(AlertService);
  workspaceTypes$: Observable<WorkspaceType[]>;
  workspaces$: Observable<Workspace[]>
  booking$: Observable<BookingResponse>
  coworkingId: number;
  bookingForm = this.fb.group({
      id: [0],
      userName: ['', Validators.required],
      userEmail: ['', [Validators.required, Validators.email]],
      workspaceTypeId: [0, Validators.required],
      capacity: [0, Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required]
    }, {validators: bookingDateValidator});

  ngOnInit(){
    this.coworkingId = this.route.snapshot.params['coworkingId'];
    this.booking$ = this.route.paramMap.pipe(
      map(params => params.get('bookingId')),
      switchMap(id => id ? this.bookingService.getById(+id) : of(null)),
      tap(booking => {
        if (booking) this.bookingForm.patchValue({
          id: booking.id,
          userName: booking.userName,
          userEmail: booking.userEmail,
          workspaceTypeId: booking.workspaceType.id,
          capacity: booking.capacity,
          startDate: booking.startDate,
          endDate: booking.endDate,
          startTime: booking.startTime ? booking.startTime.slice(0, 5) : '',
          endTime: booking.endTime ? booking.endTime.slice(0, 5) : ''
        });
        if(booking){
          this.coworkingId = booking.coworkingId;
          this.workspaceTypes$ = this.coworkingService.GetAllCoworkingWorkspaceTypes(this.coworkingId);
        }
        setTimeout(() => this.initializeFlatpickr(), 0)
      })
    );
    

    this.workspaces$ = this.bookingForm.get('workspaceTypeId').valueChanges.pipe(
    switchMap((id: any) => this.workspaceService.getAll(id)),
    map((workspaces: Workspace[]) => {
      return workspaces.filter((workspace, index, self) =>
        index === self.findIndex(ws => ws.capacity === workspace.capacity)
      );
    })
    );
  }
  onSubmit(){
    this.bookingForm.markAllAsTouched();
    if (this.bookingForm.invalid){
      return;
    }
    const bookingRequest: BookingRequest = {
      id: this.bookingForm.value.id,
      userName: this.bookingForm.value.userName,
      userEmail: this.bookingForm.value.userEmail,
      workspaceTypeId: this.bookingForm.value.workspaceTypeId,
      coworkingId: this.coworkingId,
      capacity: this.bookingForm.value.capacity,
      startDate: this.bookingForm.value.startDate,
      endDate: this.bookingForm.value.endDate,
      startTime: this.bookingForm.value.startTime,
      endTime: this.bookingForm.value.endTime
    };
    if(this.bookingForm.value.id === 0){
      this.bookingService.create(bookingRequest).subscribe({next: (res) => {
        this.alertService.success("Your room is succesfully booked");
        this.router.navigateByUrl('my_bookings');
      }, error: (err) => {
        this.alertService.error(err.message);
      }})
    } else {
      this.bookingService.update(bookingRequest).subscribe({next: (res) => {
        this.alertService.success("Your booking is succesfully updated");
        this.router.navigateByUrl('my_bookings');}, 
        error: (err) => {
        this.alertService.error(err.message);
        }
      })
    }
  }

  get f() {
    return this.bookingForm.controls;
  } 


  initializeFlatpickr(): void {
    flatpickr(this.startDateInput.nativeElement, {
      minDate: 'today',
      defaultDate: this.bookingForm.value.startDate || null,
    });

    flatpickr(this.endDateInput.nativeElement, {
      minDate: 'today', 
      defaultDate: this.bookingForm.value.endDate || null,
      allowInput: true,
      onChange: (selectedDates) => this.validateDateRange(selectedDates[0])
    });

    flatpickr(this.startTimeInput.nativeElement, {
      enableTime: true,
      noCalendar: true,
      dateFormat: 'H:i',
      minuteIncrement: 30,
      time_24hr: true,
      allowInput: true,
      defaultDate: this.bookingForm.value.startTime || null,
      onChange: (selectedDates) => this.updateEndTimePicker(selectedDates[0])
    });

    flatpickr(this.endTimeInput.nativeElement, {
      enableTime: true,
      noCalendar: true,
      dateFormat: 'H:i',
      time_24hr: true,
      defaultDate: this.bookingForm.value.endTime || null,
      minuteIncrement: 30
    });
  }

  updateEndDatePicker(startDate: Date) {
    const maxDays = this.bookingForm.value.workspaceTypeId === 3 ? 1 : 30; 
    const endPicker = this.endDateInput.nativeElement._flatpickr;

    if (endPicker) {
      const maxEndDate = new Date(startDate);
      maxEndDate.setDate(startDate.getDate() + maxDays - 1);
      endPicker.set('minDate', startDate);
      endPicker.set('maxDate', maxEndDate);
    }
  }

  updateEndTimePicker(startTime: Date) {
    const endPicker = this.endTimeInput.nativeElement._flatpickr;

    if (endPicker) {
      endPicker.set('minTime', startTime);
    }
  }

  validateDateRange(endDate: Date) {
    const startDate = this.startDateInput.nativeElement._flatpickr.selectedDates[0];

    if (!startDate) return;

    const diffDays = (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24) + 1;
    if ((this.bookingForm.value.workspaceTypeId === 3 && diffDays > 1) || diffDays > 30) {
      alert('Exceeded max booking duration!');
    }
  }
}


