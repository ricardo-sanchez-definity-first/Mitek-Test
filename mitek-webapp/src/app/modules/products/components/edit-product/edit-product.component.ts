import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../model/product';
import { ProductsService } from '../../products-service.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  productForm: FormGroup;
  id: number;
  product: Product = new Product();

  constructor(private productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      category: new FormControl(0, Validators.required)
    })
    this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.productsService.getProduct(this.id).then((p: Product) => {
        this.product = p;
        this.productForm.setValue(this.product);
      })
    })
  }

  onSubmit(): void {
    const newProduct = this.productForm.value;
    this.product = new Product(newProduct);
    this.productsService.updateProduct(this.id, this.product).then((product: Product) => {
      this.router.navigate([`products/${product.id}`])
    })
  }

}
