import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { SignInPageComponent } from "./components/sign-in-page/sign-in-page.component";

const routes: Routes = [
  {
    path: '',
    component: SignInPageComponent
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
export class SignInRoutingModule {}