import {it, describe, expect, inject, async, beforeEach, beforeEachProviders} from "@angular/core/testing";
import {ComponentFixture, TestComponentBuilder} from "@angular/compiler/testing";

import {SpinnerModalComponent, SpinnerModalService, DEFAULT_SPINNER_MESSAGE, DEFAULT_SPINNER_IMAGE} from "./index";


describe("spinner modal component", () => {
    let componentBuilder: TestComponentBuilder;

    beforeEachProviders(() => [SpinnerModalService]);

    beforeEach(inject([TestComponentBuilder], (tcb: TestComponentBuilder) => {
        componentBuilder = tcb;
    }));

    it("should display default message when no messge is specified", async(() => {
        // arrange, act
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                fixture.detectChanges();
                // assert
                let element: any = fixture.debugElement.nativeElement.querySelector("#j2bi-spinner-modal-message");
                expect(element).toHaveText(DEFAULT_SPINNER_MESSAGE);
            });
    }));

    it("should display passed in message when spinner is displayed", async(() => {
        // arrange, act
        let inputMessage = "This is test message";
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                fixture.componentInstance.message = inputMessage;
                fixture.detectChanges();
                // assert
                let element: any = fixture.debugElement.nativeElement.querySelector("#j2bi-spinner-modal-message");
                expect(element).toHaveText(inputMessage);
            });
    }));

    it("should display default spinner image when no image is specified", async(() => {
        // arrange, act
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                fixture.detectChanges();
                // assert
                let element: any = fixture.debugElement.nativeElement.querySelector("#j2bi-spinner-modal-image");
                expect(element.src).toContain(DEFAULT_SPINNER_IMAGE);
            });
    }));

    it("should display specified spinner image", async(() => {
        // arrange, act
        let spinnerImage = "testloader.gif";
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                fixture.componentInstance.spinnerImage = spinnerImage;
                fixture.detectChanges();
                // assert
                let element: any = fixture.debugElement.nativeElement.querySelector("#j2bi-spinner-modal-image");
                expect(element.src).toContain(spinnerImage);
            });
    }));


    it("should display modal when show is called", async(() => {
        // arrange, act
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                let modalSpy: any = spyOn($.fn, "modal");
                fixture.componentInstance.show();
                fixture.detectChanges();
                // assert
                expect(modalSpy).toHaveBeenCalledWith("show");
            });
    }));

    it("should hide modal when hide is called", async(() => {
        // arrange, act
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                let modalSpy: any = spyOn($.fn, "modal");
                fixture.componentInstance.hide();
                fixture.detectChanges();
                // assert
                expect(modalSpy).toHaveBeenCalledWith("hide");
            });
    }));

    it("should hide modal when spinnerDisplayEvent is fired with false", async(inject([SpinnerModalService], (service) => {
        // arrange
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                let hideSpy: any = spyOn(fixture.componentInstance, "hide");
                service.spinnerDisplayEvent.subscribe(val => {
                    // assert
                    expect(hideSpy).toHaveBeenCalled();
                });
                // act
                service.spinnerDisplayEvent.emit(false);
                fixture.detectChanges();
            });
    })));

    it("should show modal when spinnerDisplayEvent is fired with true", async(inject([SpinnerModalService], (service) => {
        // arrange
        componentBuilder.createAsync(SpinnerModalComponent)
            .then((fixture: ComponentFixture<SpinnerModalComponent>) => {
                let showSpy: any = spyOn(fixture.componentInstance, "show");
                service.spinnerDisplayEvent.subscribe(val => {
                    // assert
                    expect(showSpy).toHaveBeenCalled();
                });
                // act
                service.spinnerDisplayEvent.emit(true);
                fixture.detectChanges();
            });
    })));
});
