import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProductComponent } from './components/add-product/add-product.component';
import { ProductsRoutingModule } from './products-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ProductsService } from './products-service.service';
import { HttpClientModule } from '@angular/common/http';
import { DetailProductComponent } from './components/detail-product/detail-product.component';

@NgModule({
  declarations: [AddProductComponent, DetailProductComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    ProductsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule
  ],
  providers: [ProductsService]
})
export class ProductsModule { }
