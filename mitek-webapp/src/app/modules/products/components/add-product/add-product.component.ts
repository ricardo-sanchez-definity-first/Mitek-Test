import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from '../../model/product';
import { ProductsService } from '../../products-service.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  productForm: FormGroup;
  newProduct: Product = new Product();

  constructor(private readonly productsService: ProductsService, private router: Router) { }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      category: new FormControl(0, Validators.required)
    })
  }

  onSubmit(): void {
    const newProduct = this.productForm.value;
    this.newProduct = new Product(newProduct);
    this.productsService.createProduct(this.newProduct).then((product: Product) => {
      this.router.navigate([`products/${product.id}`])
    })
  }

}
