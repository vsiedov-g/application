import { Routes } from "@angular/router";
import { MyBookingsComponent } from "./features/my-bookings/my-bookings.component";
import { WorkspaceTypeListComponent } from "./features/workspace-type-list/workspace-type-list.component";
import { BookingPageComponent } from "./features/booking-page/booking-page.component";

export const routes: Routes = [
    {
        path: '',
        component: WorkspaceTypeListComponent
    },
    {
        path: 'my_bookings',
        component: MyBookingsComponent
    },
    {
        path: 'booking',
        component: BookingPageComponent,
    },
    {
        path: 'booking/:id',
        component: BookingPageComponent,
    }
];
