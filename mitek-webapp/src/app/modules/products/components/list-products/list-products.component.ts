import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../../model/product';
import { ProductsService } from '../../products-service.service';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.scss']
})
export class ListProductsComponent implements OnInit {
  products: Product[] = [];
  displayedColumns: string[] = ['Id', 'Name', 'Category', 'Description']

  constructor(private productsService: ProductsService, private router: Router) { }

  ngOnInit(): void {
    this.productsService.getProducts().then((ps: Product[]) => {
      this.products = ps;
    })
  }

  editRow(product: Product): void {
    this.router.navigate([`products/${product.id}`])
  }

  create(): void {
    this.router.navigate(['products/create'])
  }

}
