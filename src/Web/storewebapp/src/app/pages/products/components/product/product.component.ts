import { Component, Input, OnInit } from '@angular/core';
import { ProductsService } from '../../products.service';
import { IProduct } from '../../utils/products.types';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  @Input() product: IProduct = {
    id: 0,
    name: 'produto 1',
    description: 'novo produto',
    price: 50,
    category: 'categoria 1',
  }

  constructor(private service: ProductsService) { }

  ngOnInit(): void {
  }

}
