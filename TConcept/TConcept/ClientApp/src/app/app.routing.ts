import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { ComponentsComponent } from './components/components.component';
import { ProfileComponent } from './examples/profile/profile.component';
import { SignupComponent } from './examples/signup/signup.component';
import { LandingComponent } from './examples/landing/landing.component';
import { NucleoiconsComponent } from './components/nucleoicons/nucleoicons.component';
import { CustomComponent } from './custom/custom.component';
import { SofaComponent } from './sofa/sofa.component';
import { SofaDetailComponent } from './sofa/sofa-detail/sofa-detail.component';
import { LoginComponent } from './login/login.component';
import { ConfirmOrderComponent } from './confirm-order/confirm-order.component';
import { ManagementComponent } from './management/management.component';
import { OrderManagementComponent } from './management/order-management/order-management.component';


const routes: Routes =[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home',             component: ComponentsComponent },
    { path: 'user-profile',     component: ProfileComponent },
    { path: 'signup',           component: SignupComponent },
    { path: 'landing',          component: LandingComponent },
    { path: 'nucleoicons',      component: NucleoiconsComponent },
    { path: 'custom',          component: CustomComponent },
    { path: 'sofa',          component: SofaComponent },
    { path: 'sofa-detail',          component: SofaDetailComponent },
    { path: 'login',          component: LoginComponent },
    { path: 'confirm-order',          component: ConfirmOrderComponent },
    { path: 'management',          component: ManagementComponent },
    { path: 'order-management',          component: OrderManagementComponent }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: false
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
