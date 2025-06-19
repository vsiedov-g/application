import { CommonModule, DatePipe } from '@angular/common';
import { Component, inject, Input, input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { WORKSPACE_TYPE_NAME } from 'src/app/core/constants/workspacetype-names';
import { BookingResponse } from 'src/app/core/models/booking.model';
import { WorkspaceType } from 'src/app/core/models/workspace-type.model';
import { Workspace } from 'src/app/core/models/workspace.model';

@Component({
  selector: 'app-workspace-type-item',
  standalone: true,
  imports: [CommonModule, RouterModule],
  providers: [DatePipe],
  templateUrl: './workspace-type-item.component.html',
  styleUrl: './workspace-type-item.component.css'
})
export class WorkspaceTypeItemComponent {
  @Input() workspaceType: WorkspaceType;
  @Input() booking?: BookingResponse;
  @Input() coworkingId: number;
  private datePipe = inject(DatePipe);
  capacityOptions: Workspace[];
  groupedAvailability: { capacity: number; count: number }[] = [];
  deskCount: number;
  ngOnInit()
  {
    console.log(this.workspaceType)
  }

  formatAvailability(count: number, capacity: number): string{
    if(this.workspaceType.name === WORKSPACE_TYPE_NAME.OPEN_SPACE){
      return `${count} desk${count !== 1 ? 's' : ''} available`;
    } 
    if(this.workspaceType.name === WORKSPACE_TYPE_NAME.PRIVATE_ROOM){
      return `${count} room${count !== 1 ? 's' : ''} for ${count !== 1 ? '' : 'up to'} ${capacity} ${capacity !== 1 ? 'people' : 'person'}`;
    }
    if(this.workspaceType.name === WORKSPACE_TYPE_NAME.MEETING_ROOM){
      return `${count} meeting room${count !== 1 ? 's' : ''}`;
    }
    return 'No available workspaces';
  }

  formatBookingMessage(): string{
    const formattedStartDate = this.datePipe.transform(this.booking.startDate, 'MMM d, yyyy')
    const formattedEndDate = this.datePipe.transform(this.booking.endDate, 'MMM d, yyyy')
    if(this.workspaceType.name === WORKSPACE_TYPE_NAME.OPEN_SPACE){
      return `This place is already booked by you! Desk ${formattedStartDate} - ${formattedEndDate}`
    }
    return `This place is already booked by you! Room for ${this.booking.capacity} ${this.booking.capacity !== 1 ? 'people' : 'person'} ${formattedStartDate} - ${formattedEndDate}`;
  }
}
