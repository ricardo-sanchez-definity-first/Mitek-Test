import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from './components/add-product/add-product.component';
import { DetailProductComponent } from './components/detail-product/detail-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { ListProductsComponent } from './components/list-products/list-products.component';

const routes: Routes = [
  {
    path: '', component: ListProductsComponent
  },
  {
    path: 'create', component: AddProductComponent
  },
  {
    path: ':id', component: DetailProductComponent
  },
  {
    path: 'edit/:id', component: EditProductComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
