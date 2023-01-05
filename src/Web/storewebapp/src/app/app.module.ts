import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoModule } from '@po-ui/ng-components';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { ProductComponent } from './products/components/product/product.component';
import { ListProductsComponent } from './products/components/list-products/list-products.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AddProductComponent } from './products/components/add-product/add-product.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ListProductsComponent,
    SidenavComponent,
    AddProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PoModule,
    PoTemplatesModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
