import { Injectable } from '@angular/core';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  
  success(message: string, title: string = 'Success'): Promise<SweetAlertResult<any>> {
    return Swal.fire({
      title,
      text: message,
      icon: 'success',
      timer: 2000,
      showConfirmButton: false
    });
  }
  
  error(message: string, title: string = 'Error'): Promise<SweetAlertResult<any>> {
    return Swal.fire({
      title,
      text: message,
      icon: 'error',
      confirmButtonText: 'Ok'
    });
  }
  
  confirm(message: string, title: string = 'Confirm'): Promise<SweetAlertResult<any>> {
    return Swal.fire({
      title,
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    });
  }

}
