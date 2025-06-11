import { CommonModule } from '@angular/common';
import { Component, Input, input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BookingResponse } from 'src/app/core/models/booking.model';
import { WorkspaceType } from 'src/app/core/models/workspace-type.model';
import { Workspace } from 'src/app/core/models/workspace.model';

@Component({
  selector: 'app-workspace-type-item',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './workspace-type-item.component.html',
  styleUrl: './workspace-type-item.component.css'
})
export class WorkspaceTypeItemComponent {
  @Input() workspaceType: WorkspaceType;
  @Input() booking?: BookingResponse;
  capacityOptions: Workspace[];
  groupedAvailability: { capacity: number; count: number }[] = [];
  deskCount: number;
  ngOnChanges()
  {
    if (this.workspaceType){
      if(this.workspaceType.name === "Open Space"){
        this.deskCount = this.workspaceType.workspaces.reduce((sum, w) => sum + w.capacity, 0);
      }
      this.capacityOptions = this.workspaceType.workspaces.filter(
      (workspace, index, self) =>
        index === self.findIndex(ws => ws.capacity === workspace.capacity)
      );
      const map = new Map<number, number>();
      this.workspaceType.workspaces.forEach(ws => {
        map.set(ws.capacity, (map.get(ws.capacity) || 0) + 1);
      });
      this.groupedAvailability = Array.from(map.entries()).map(([capacity, count]) => ({
        capacity,
        count
      }));
    }
  }
}
