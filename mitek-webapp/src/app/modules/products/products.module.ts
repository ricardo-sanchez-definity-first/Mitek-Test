import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ProductsService } from './products-service.service';

import { AddProductComponent } from './components/add-product/add-product.component';
import { DetailProductComponent } from './components/detail-product/detail-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { ListProductsComponent } from './components/list-products/list-products.component';

import { MatSelectModule } from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [AddProductComponent, DetailProductComponent, EditProductComponent, ListProductsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    ProductsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule
  ],
  providers: [ProductsService]
})
export class ProductsModule { }
