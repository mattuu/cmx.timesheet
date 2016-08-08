import {it, describe, expect, inject, async, beforeEach, beforeEachProviders} from "@angular/core/testing";

import {ConfirmationModalService, ModalContext} from "./index";

describe("Confirmation modal service", () => {
    let sut: ConfirmationModalService;

    beforeEachProviders(() => [ConfirmationModalService]);

    beforeEach(inject([ConfirmationModalService], (confirmationModalService: ConfirmationModalService) => {
        sut = confirmationModalService;
    }));

    describe("when show is called", () => {

        it("should emit confirmationModalDisplayEvent", async(() => {
            // arrange
            let message = "test message";
            let title = "test title";
            let buttons = [];
            let context = "warn" as ModalContext;
            let dismissable = true;
            sut.confirmationModalDisplayEvent.subscribe((val: any) => {
                // assert
                expect(val.message).toBe(message);
                expect(val.title).toBe(title);
                expect(val.buttons).toBe(buttons);
                expect(val.context).toBe(context);
                expect(val.dismissable).toBe(dismissable);
            });
            // act
            sut.show(title, message, buttons, context, dismissable);
        }));

        it("should use default values for context and dismissable", async(() => {
            // arrange
            let message = "test message";
            let title = "test title";
            let buttons = [];
            sut.confirmationModalDisplayEvent.subscribe((val: any) => {
                // assert
                expect(val.context).toBe("info");
                expect(val.dismissable).toBe(false);
            });
            // act
            sut.show(title, message, buttons);
        }));
    });
    it("should emit confirmationModalDisplayEvent with false when hide is called", async(() => {
        // arrange
        sut.confirmationModalDisplayEvent.subscribe((val: any) => {
            // assert
            expect(val).toBe(false);
        });
        // act
        sut.hide();
    }));
});
