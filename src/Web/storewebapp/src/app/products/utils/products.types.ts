import { IPageableQuery, IPageableResult } from "src/app/api/common.types";

export interface IProduct {
    id: number;
    name: string;
    description?: string | null;
    price: number;
    category?: string | null;
}

export enum ProductOrderBy {
    NAME_ASC = 1,
    NAME_DESC = 2
}

export interface IProductsListFilter extends IPageableQuery<ProductOrderBy, IProduct> {}