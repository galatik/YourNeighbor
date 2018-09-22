import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInPageComponent } from './components/sign-in-page/sign-in-page.component';
import { SignInRoutingModule } from './sign-in-routing.module';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SignInRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  declarations: [SignInPageComponent]
})
export class SignInModule { }
