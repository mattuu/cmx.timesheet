import {provide} from "@angular/core";
import {it, describe, expect, inject, async, beforeEach, beforeEachProviders} from "@angular/core/testing";
import {MockBackend, MockConnection} from "@angular/http/testing";
import {BaseRequestOptions, ConnectionBackend, Http, Response, ResponseOptions} from "@angular/http";

import {Observable} from "rxjs/Observable";
import "rxjs/Rx";

import {HttpService} from "./http.service";

describe("http service", () => {
    let sut: HttpService;
    let connectionBackend: MockBackend;

    beforeEachProviders(() => [HttpService, MockBackend, BaseRequestOptions, provide(Http, {
        useFactory: (backend: ConnectionBackend, requestOptions: BaseRequestOptions) => new Http(backend, requestOptions),
        deps: [MockBackend, BaseRequestOptions] // create angular's http service using mockbackend
    })]);

    beforeEach(inject([HttpService, MockBackend], (httpService: HttpService, mockBackend: MockBackend) => {
        sut = httpService;
        connectionBackend = mockBackend;
    }));

    describe("get", () => {
        it("should throw on error", async(() => {
            // arrange
            let testUrl = "http://test/url1";
            connectionBackend.connections.subscribe((connection: MockConnection) => {
                connection.mockError({ name: "error", message: "error message" });
            });
            // act
            sut.get(testUrl)
                .catch(err => {
                    expect(err).toBeDefined();
                    return Observable.empty();
                });
        }));

        it("should parse json response correctly", async(() => {
            // arrange
            let testUrl = "http://test/url1";
            let responseData: TestClass = {
                id: 1,
                name: "testname"
            };

            connectionBackend.connections.subscribe((connection: MockConnection) => {
                connection.mockRespond(new Response(new ResponseOptions({ body: responseData })));
            });
            // act
            sut.get<TestClass>(testUrl)
                .subscribe((result: TestClass) => {
                    expect(result).toBe(responseData);
                });
        }));


    });


});


class TestClass {
    id: number;
    name: string;
}