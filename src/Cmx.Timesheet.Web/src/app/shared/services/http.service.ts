import {Injectable} from "@angular/core";
import {Http, Response} from "@angular/http";
import {Observable} from "rxjs/Observable";
import "rxjs/Rx";


@Injectable()
export class HttpService {

    constructor(private http: Http) {
    }

    get<T>(url: string): Observable<T> {
        return this.http.get("http://localhost/J2BI.Namespace.Template.Web" + url)
            .map((response: Response) => this.processResponse<T>(response))
            .catch(this.handleError);
    }

    private processResponse<T>(response: Response): T {
        return response.json() as T; //TODO: MV: expand to catch errors and json parsing failures
    }

    private handleError(error: any) {
        // TODO: MV: LOG HERE
        return Observable.throw(error);
    }
}

