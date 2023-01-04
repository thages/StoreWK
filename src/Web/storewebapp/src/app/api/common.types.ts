

interface IPageableQuery<T, U> extends Omit<IPageableResult<U>, "results"> {
    orderBy?: T;
}

interface IPageableResult<T> {
    pageSize: number;
    currentPage: number;
    results: T[];
}

export { IPageableQuery, IPageableResult };