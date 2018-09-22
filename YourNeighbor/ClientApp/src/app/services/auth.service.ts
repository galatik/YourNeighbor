import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  public get isUserAuthorized(): boolean {
    return false;
  }
}
