import { Component, inject } from '@angular/core';
import { HeaderComponent } from './shared/header/header.component';
import { RouterOutlet } from '@angular/router';
import { WorkspaceTypeListComponent } from './features/workspace-type-list/workspace-type-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, WorkspaceTypeListComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

}
