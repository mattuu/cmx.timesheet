import {it, describe, expect, inject, async, beforeEach} from "@angular/core/testing";
import {ComponentFixture, TestComponentBuilder} from "@angular/compiler/testing";

import {SpinnerComponent, DEFAULT_SPINNER_IMAGE} from "./index";


describe("spinner component", () => {
    let componentBuilder: TestComponentBuilder;

    beforeEach(inject([TestComponentBuilder], (tcb: TestComponentBuilder) => {
        componentBuilder = tcb;
    }));

    describe("when isBusy is truthy", () => {
        let isBusy: boolean;
        beforeEach(() => {
            isBusy = true;
        });

        it("spinner should be displayed", async(() => {
            // arrange, act
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let element: any = fixture.debugElement.nativeElement.querySelector(".spinner");
                    expect(element).toBeDefined();

                });
        }));

        it("spinner should be displayed with default value when no values specified", async(() => {
            // arrange, act
            let defaultSize = 25;
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let imageElement: any = fixture.debugElement.nativeElement.querySelector(".j2bi-spinner-image");
                    expect(imageElement.height).toBe(defaultSize);
                    expect(imageElement.width).toBe(defaultSize);
                    expect(imageElement.src).toContain(DEFAULT_SPINNER_IMAGE);
                });
        }));

        it("spinner message should not be displayed when no message is specified", () => {
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let messageElement: any = fixture.debugElement.nativeElement.querySelector(".j2bi-spinner-message");
                    expect(messageElement).toBeNull();
                });
        });

        it("spinner should be displayed with specified values", async(() => {
            // arrange, act
            let spinnerSize = 35;
            let spinnerMessage = "Test message";
            let spinnerImage = "/test.gif";

            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.componentInstance.spinnerSize = spinnerSize;
                    fixture.componentInstance.message = spinnerMessage;
                    fixture.componentInstance.spinnerImage = spinnerImage;
                    fixture.detectChanges();
                    // assert
                    let imageElement: any = fixture.debugElement.nativeElement.querySelector(".j2bi-spinner-image");
                    let messageElement: any = fixture.debugElement.nativeElement.querySelector(".j2bi-spinner-message");
                    expect(imageElement.height).toBe(spinnerSize);
                    expect(imageElement.width).toBe(spinnerSize);
                    expect(imageElement.src).toContain(spinnerImage);
                    expect(messageElement).toHaveText(spinnerMessage);
                });
        }));

        it("content should not be displayed", async(() => {
            // arrange, act
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let element: any = fixture.debugElement.nativeElement.querySelector(".content");
                    expect(element).toBeNull();
                });
        }));
    });

    describe("when isBusy is falsy", () => {
        let isBusy: boolean;
        beforeEach(() => {
            isBusy = false;
        });

        it("spinner should not be displayed", async(() => {
            // arrange, act
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let element: any = fixture.debugElement.nativeElement.querySelector(".spinner");
                    expect(element).toBeNull();
                });
        }));

        it("content should be displayed", async(() => {
            // arrange, act
            componentBuilder.createAsync(SpinnerComponent)
                .then((fixture: ComponentFixture<SpinnerComponent>) => {
                    fixture.componentInstance.isBusy = isBusy;
                    fixture.detectChanges();
                    // assert
                    let element: any = fixture.debugElement.nativeElement.querySelector(".content");
                    expect(element).toBeDefined();
                });
        }));
    });
});
