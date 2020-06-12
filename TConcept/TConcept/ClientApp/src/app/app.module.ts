import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';

import { ComponentsModule } from './components/components.module';
import { ExamplesModule } from './examples/examples.module';
import { HttpClientModule } from '@angular/common/http';
import { SofaComponent } from './sofa/sofa.component';
import { SofaDetailComponent } from './sofa/sofa-detail/sofa-detail.component';
import { ManagementComponent } from './management/management.component';
import { OrderManagementComponent } from './management/order-management/order-management.component';
import { ProductManagementComponent } from './management/product-management/product-management.component';
import { LoginComponent } from './login/login.component';
import { ConfirmOrderComponent } from './confirm-order/confirm-order.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    SofaComponent,
    SofaDetailComponent,
    ManagementComponent,
    OrderManagementComponent,
    ProductManagementComponent,
    LoginComponent,
    ConfirmOrderComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule,
    RouterModule,
    ComponentsModule,
    ExamplesModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
