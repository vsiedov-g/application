import { HttpClient} from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { API_ENDPOINTS } from "../constants/api-endpoints";
import { BookingRequest, BookingResponse } from "../models/booking.model";



@Injectable({providedIn: 'root'})
export class BookingService {
    private http = inject(HttpClient)
    getAll(){
        return this.http.get<BookingResponse[]>(API_ENDPOINTS.BOOKING);  
    }
    getById(Id: number){
        return this.http.get<BookingResponse>(`${API_ENDPOINTS.BOOKING}/${Id}`);
    }
    update(booking: BookingRequest){
        return this.http.patch(`${API_ENDPOINTS.BOOKING}/${booking.id}`, booking);
    }
    create(booking: BookingRequest){
        return this.http.post(API_ENDPOINTS.BOOKING, booking);
    }
    delete(Id: number){
        return this.http.delete(`${API_ENDPOINTS.BOOKING}/${Id}`);
    }
    aiHelper(message: string){
        let form = new FormData()
        form.append('message', message)
        return this.http.post<{response: string}>(API_ENDPOINTS.BOOKING_AI, form);
    }
}
