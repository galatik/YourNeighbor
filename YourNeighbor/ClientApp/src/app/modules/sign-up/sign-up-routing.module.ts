import { Routes, RouterModule } from "@angular/router";
import { SignUpPageComponent } from "./components/sign-up-page/sign-up-page.component";
import { NgModule } from "@angular/core";

const routes: Routes = [
  {
    path: '',
    component: SignUpPageComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class SignUpRoutingModule {}