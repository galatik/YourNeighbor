import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.css']
})
export class SignInPageComponent implements OnInit {
  private passwordRegexp: RegExp;
  public signInForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.passwordRegexp = new RegExp(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/);
    this.signInForm = formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern(this.passwordRegexp)]]
    })
  }

  ngOnInit() {
  }

  public get submitState(): boolean {
    return !this.signInForm.valid;
  }

  public onSubmit(): void {
    
  }

}
