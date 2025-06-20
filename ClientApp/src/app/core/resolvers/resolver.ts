import { ResolveFn, Router } from "@angular/router";
import { Coworking } from "../models/coworking.model";
import { inject } from "@angular/core";
import { CoworkingService } from "../services/coworkings.service";
import { catchError, EMPTY, map } from "rxjs";

export const CoworkingBookingResolver : ResolveFn<Coworking> = (route, state) => {
    const coworkingService = inject(CoworkingService);
    const router = inject(Router);
     return coworkingService.get(+route.paramMap.get('coworkingId')).pipe(
        map(coworking => {
            if (!coworking) {
                router.navigateByUrl('');;
                return null; 
            }
            return coworking;
        }),
        catchError(() => {
            router.navigateByUrl('');
            return EMPTY;
        })
    );
} 