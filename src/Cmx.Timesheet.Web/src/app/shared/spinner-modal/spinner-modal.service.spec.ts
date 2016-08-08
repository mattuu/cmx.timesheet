import {it, describe, expect, inject, async, beforeEach, beforeEachProviders} from "@angular/core/testing";

import {SpinnerModalService} from "./spinner-modal.service";

describe("spinner modal service", () => {
    let sut: SpinnerModalService;

    beforeEachProviders(() => [SpinnerModalService]);

    beforeEach(inject([SpinnerModalService], (spinnerService: SpinnerModalService) => {
        sut = spinnerService;
    }));

    it("should emit spinnerDisplayEvent with true when show is called", (done: Function) => {
        // arrange
        sut.spinnerDisplayEvent.subscribe((val: any) => {
            // assert
            expect(val).toBe(true);
            done();
        });
        // act
        sut.show();
    });

    it("should emit spinnerDisplayEvent with false when hide is called", async(() => {
        // arrange
        sut.spinnerDisplayEvent.subscribe((val: any) => {
            // assert
            expect(val).toBe(false);
        });
        // act
        sut.hide();
    }));
});
