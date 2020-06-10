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
import { ManagementComponent } from './management/management.component';
import { OrderMaangementComponent } from './management/order-maangement/order-maangement.component';
import { ProductMaanngementComponent } from './management/product-maanngement/product-maanngement.component';
import { OrderManagementComponent } from './management/order-management/order-management.component';
import { ProductManagementComponent } from './management/product-management/product-management.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    SofaComponent,
    ManagementComponent,
    OrderMaangementComponent,
    ProductMaanngementComponent,
    OrderManagementComponent,
    ProductManagementComponent
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
