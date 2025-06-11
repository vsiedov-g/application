import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const bookingDateValidator: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
  const startDateControl = group.get('startDate');
  const endDateControl = group.get('endDate');
  const workspaceTypeIdControl = group.get('workspaceTypeId');

  if (!startDateControl || !endDateControl || !workspaceTypeIdControl) {
    return null;
  }

  const startDateValue = startDateControl.value;
  const endDateValue = endDateControl.value;
  const workspaceTypeId = +workspaceTypeIdControl.value;

  if (!startDateValue || !endDateValue) {
    return null;
  }

  const sDate = new Date(startDateValue);
  const eDate = new Date(endDateValue);
  const today = new Date();
  today.setHours(0, 0, 0, 0);

  if (sDate < today) {
    return { pastDate: true };
  }

  if (sDate > eDate) {
    return { dateOrderInvalid: true };
  }

  const diffDays = Math.floor((eDate.getTime() - sDate.getTime()) / (1000 * 60 * 60 * 24)) + 1;

  if (workspaceTypeId === 3) {
    if (diffDays > 1) {
      return { durationExceeded: 'Meeting room bookings cannot exceed 1 day.' };
    }
  } else {
    if (diffDays > 30) {
      return { durationExceeded: 'Bookings for this workspace cannot exceed 30 days.' };
    }
  }

  return null;
};


