import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent implements OnInit {
  public signUpDisabled: boolean;
  public signInDisabled: boolean;

  constructor(
    private router: Router
  ) {
    this.signInDisabled = false;
    this.signUpDisabled = false;
  }

  ngOnInit() {
  }

  public signUp(): void {
    this.signUpDisabled = true;
    this.router.navigate(['signup']);
  }

  public signIn(): void {
    this.signInDisabled = true;
    this.router.navigate(['signin']);
  }

}
