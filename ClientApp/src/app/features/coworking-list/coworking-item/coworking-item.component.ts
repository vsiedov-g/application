import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { WORKSPACE_TYPE_NAME } from 'src/app/core/constants/workspacetype-names';
import { Coworking } from 'src/app/core/models/coworking.model';

@Component({
  selector: 'app-coworking-item',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './coworking-item.component.html',
  styleUrl: './coworking-item.component.css'
})
export class CoworkingItemComponent {
  @Input() coworking: Coworking
  ngOnInit()
  {
    console.log(this.coworking);
  }

  formatAvailability(count: number, workspaceType: string): string{
    if(!count && !workspaceType){
      return "No available workspaces";
    }
    if(workspaceType === WORKSPACE_TYPE_NAME.OPEN_SPACE){
      return `🪑 ${count} desk${count !== 1 ? 's' : ''}`;
    } 
    if(workspaceType === WORKSPACE_TYPE_NAME.PRIVATE_ROOM){
      return `🔒 ${count} private room${count !== 1 ? 's' : ''}`;
    }
    if(workspaceType === WORKSPACE_TYPE_NAME.MEETING_ROOM){
      return `📊 ${count} meeting room${count !== 1 ? 's' : ''}`;
    }
    return 'No available workspaces';
  }
}
