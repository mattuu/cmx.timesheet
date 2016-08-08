import {it, describe, expect, inject, async, beforeEach, beforeEachProviders} from "@angular/core/testing";
import {ComponentFixture, TestComponentBuilder} from "@angular/compiler/testing";

import {ConfirmationModalComponent, ConfirmationModalService, ModalContext} from "./index";


describe("confirmation modal component", () => {
    let componentBuilder: TestComponentBuilder;

    beforeEachProviders(() => [ConfirmationModalService]);

    beforeEach(inject([TestComponentBuilder], (tcb: TestComponentBuilder) => {
        componentBuilder = tcb;
    }));

    it("should display modal when show is called", async(() => {
        // arrange, act
        componentBuilder.createAsync(ConfirmationModalComponent)
            .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                let modalSpy: any = spyOn($.fn, "modal");
                fixture.componentInstance.show();
                fixture.detectChanges();
                // assert
                expect(modalSpy).toHaveBeenCalledWith("show");
            });
    }));

    it("should hide modal when hide is called", async(() => {
        // arrange, act
        componentBuilder.createAsync(ConfirmationModalComponent)
            .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                let modalSpy: any = spyOn($.fn, "modal");
                fixture.componentInstance.hide();
                fixture.detectChanges();
                // assert
                expect(modalSpy).toHaveBeenCalledWith("hide");
            });
    }));

    describe("when confirmationModalDisplayEvent is fired with false", () => {
        it("should hide modal", async(inject([ConfirmationModalService], (service) => {
            // arrange
            componentBuilder.createAsync(ConfirmationModalComponent)
                .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                    let hideSpy: any = spyOn(fixture.componentInstance, "hide");
                    service.confirmationModalDisplayEvent.subscribe(val => {
                        // assert
                        expect(hideSpy).toHaveBeenCalled();
                    });
                    // act
                    service.confirmationModalDisplayEvent.emit(false);
                    fixture.detectChanges();
                });
        })));
    });

    describe("when confirmationModalDisplayEvent is fired with true", () => {
        it("should show modal", async(inject([ConfirmationModalService], (service) => {
            // arrange
            componentBuilder.createAsync(ConfirmationModalComponent)
                .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                    let showSpy: any = spyOn(fixture.componentInstance, "show");
                    service.confirmationModalDisplayEvent.subscribe(val => {
                        // assert
                        expect(showSpy).toHaveBeenCalled();
                    });
                    // act
                    service.confirmationModalDisplayEvent.emit(true);
                    fixture.detectChanges();
                });
        })));

        it("should call create with correct data", async(inject([ConfirmationModalService], (service) => {
            // arrange
            let message: string = "test message";
            let title: string = "test title";
            let buttons: any[] = [];
            let context = "warn" as ModalContext;
            let dismissable = true;
            componentBuilder.createAsync(ConfirmationModalComponent)
                .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                    let showSpy: any = spyOn(fixture.componentInstance, "create");
                    service.confirmationModalDisplayEvent.subscribe(val => {
                        // assert
                        expect(showSpy).toHaveBeenCalledWith({
                            title: title,
                            message: message,
                            buttons: buttons,
                            context: context,
                            dismissable: dismissable
                        });
                    });
                    // act
                    service.confirmationModalDisplayEvent.emit({
                        title: title,
                        message: message,
                        buttons: buttons,
                        context: context,
                        dismissable: dismissable
                    });
                    fixture.detectChanges();
                });
        })));
    });

    describe("dismissAttrValue", () => {
        it("should return modal when input is true", () => {
            let input = true;
            let expected = "modal";
            componentBuilder.createAsync(ConfirmationModalComponent)
                .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                    let result = fixture.componentInstance.dismissAttrValue(input);
                    // assert
                    expect(result).toBe(expected);
                });
        });
        it("should return nothing when input is false", () => {
            let input = false;
            let expected = "";
            componentBuilder.createAsync(ConfirmationModalComponent)
                .then((fixture: ComponentFixture<ConfirmationModalComponent>) => {
                    let result = fixture.componentInstance.dismissAttrValue(input);
                    // assert
                    expect(result).toBe(expected);
                });
        });
    });
});
