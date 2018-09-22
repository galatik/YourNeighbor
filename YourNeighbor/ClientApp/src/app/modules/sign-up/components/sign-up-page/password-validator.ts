import { AbstractControl } from "@angular/forms";

export class PasswordValidator {
  static MatchPassword(AC: AbstractControl) {
    const password = AC.get('password').value;
    const password2 = AC.get('password2').value;
    if (password !== password2) {
      AC.get('password2').setErrors({ match: true });
    } else {
      return null;
    }
  }
}