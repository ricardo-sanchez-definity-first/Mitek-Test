import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../model/product';
import { ProductsService } from '../../products-service.service';

@Component({
  selector: 'app-detail-product',
  templateUrl: './detail-product.component.html',
  styleUrls: ['./detail-product.component.scss']
})
export class DetailProductComponent implements OnInit {
  id: number;
  product: Product = new Product();

  constructor(private productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router)
    { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.productsService.getProduct(this.id).then((p: Product) => {
        this.product = p;
      })
    })
  }

  editProduct(): void {
    this.router.navigate([`products/edit/${this.id}`]);
  }

  deleteProduct(): void {
    this.productsService.deleteProduct(this.id).then(r => {
      this.router.navigate(['products']);
    })
  }
}
