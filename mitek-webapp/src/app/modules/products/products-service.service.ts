import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from './model/product';

@Injectable({
  providedIn: 'any'
})
export class ProductsService {
  private apiUrl = "https://localhost:44388/api/products"

  constructor(private http: HttpClient) { }

  getProducts(): Promise<Product[]> {
    return this.http.get<Product[]>(this.apiUrl).toPromise();
  }

  getProduct(id: number): Promise<Product> {
    return this.http.get<Product>(this.apiUrl + `/${id}`).toPromise();
  }

  createProduct(product: Product): Promise<Product> {
    return this.http.post<Product>(this.apiUrl, product).toPromise();
  }

  updateProduct(id: number, product: Product): Promise<Product> {
    return this.http.put<Product>(this.apiUrl + `/${id}`, product).toPromise();
  }
  deleteProduct(id:number): Promise<boolean> {
    return this.http.delete<boolean>(this.apiUrl + `/${id}`).toPromise();
  }
}
