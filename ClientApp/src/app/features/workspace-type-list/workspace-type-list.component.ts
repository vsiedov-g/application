import { Component, inject } from '@angular/core';
import { WorkspaceTypeItemComponent } from "./workspace-type-item/workspace-type-item.component";
import { combineLatest, map, Observable } from 'rxjs';
import { WorkspaceType } from 'src/app/core/models/workspace-type.model';
import { WorkspaceTypeService } from 'src/app/core/services/workspace-type.service';
import { CommonModule } from '@angular/common';
import { BookingService } from 'src/app/core/services/booking.service';
import { BookingResponse } from 'src/app/core/models/booking.model';

@Component({
  selector: 'app-workspace-type-list',
  standalone: true,
  imports: [WorkspaceTypeItemComponent, CommonModule],
  templateUrl: './workspace-type-list.component.html',
  styleUrl: './workspace-type-list.component.css'
})
export class WorkspaceTypeListComponent {
  workspaceTypes$: Observable<WorkspaceType[]>;
  bookings$: Observable<BookingResponse[]>;
  workspaceTypesWithBooking$: Observable<
  { workspaceType: WorkspaceType; booking?: BookingResponse }[]
>;
  private workspaceTypeService = inject(WorkspaceTypeService);
  private bookingService = inject(BookingService);
  ngOnInit()
  {
    this.workspaceTypes$ = this.workspaceTypeService.getAll(true);
    this.bookings$ = this.bookingService.getAll();
    this.workspaceTypesWithBooking$ = combineLatest([this.workspaceTypes$, this.bookings$]).pipe(
    map(([types, bookings]) =>
      types.map(type => {
        const matchingBooking = bookings.find(
          b => b.workspaceType.id === type.id
        );
        return {
          workspaceType: type,
          booking: matchingBooking
        };
      })
    )
  );
  }
}
