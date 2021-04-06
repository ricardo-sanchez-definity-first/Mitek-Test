export class Product {
  id: number = 0;
  name: string = '';
  description: string = '';
  category: number = 1;

  constructor(init?: Partial<Product>){
    Object.assign(this, init);
  }
}
