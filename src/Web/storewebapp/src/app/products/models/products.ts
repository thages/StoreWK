export interface Products extends Array<Product> {}

export interface Product {
    name: string;
    description: string;
    price: number;
    category: string;
}

export interface ProductsAPI {
    payload: Products;
}