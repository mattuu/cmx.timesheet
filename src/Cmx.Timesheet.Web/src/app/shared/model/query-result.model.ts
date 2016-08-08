export class QueryResult<T>{
    associatedActions: Map<string, boolean>;
    result: T;
}