import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PasswordValidator } from './password-validator';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent implements OnInit {
  private passwordRegexp: RegExp;
  public signUpForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder
  ) {
    this.passwordRegexp = new RegExp(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/);
    this.signUpForm = formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      passwords: formBuilder.group({
        password: ['', [Validators.required, Validators.pattern(this.passwordRegexp)]],
        password2: ['', [Validators.required, Validators.pattern(this.passwordRegexp)]]
      }, { validator: PasswordValidator.MatchPassword})
    })
  }

  ngOnInit() {
  }

  public get submitState(): boolean {
    return !this.signUpForm.valid;
  }

  public onSubmit(): void {

  }

}
