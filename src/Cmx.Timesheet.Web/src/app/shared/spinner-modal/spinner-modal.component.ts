import {Component, Input} from "@angular/core";
import "bootstrap";

import {SpinnerModalService} from "./spinner-modal.service";

export const DEFAULT_SPINNER_MESSAGE: string = "Please wait...";
export const DEFAULT_SPINNER_IMAGE: string = "loader.gif";

@Component({
    moduleId: __moduleName,
    selector: "j2bi-spinner-modal",
    templateUrl: "spinner-modal.component.html",
    styleUrls: ["spinner-modal.component.css"]
})
export class SpinnerModalComponent {
    @Input() message: string;
    @Input() spinnerImage: string;
    constructor(private spinnerService: SpinnerModalService) {
        this.message = this.message || DEFAULT_SPINNER_MESSAGE;
        this.spinnerImage = this.spinnerImage || this.concatToCurrentPath(DEFAULT_SPINNER_IMAGE);
        this.addEventSubscriptions();
    }

    hide(): void {
        let $modal: any = $("#j2bi-spinner-modal");
        $modal.modal("hide");
    }

    show(): void {
        let $modal: any = $("#j2bi-spinner-modal");
        $modal.modal("show");
    }

    private addEventSubscriptions(): void {
        let self: SpinnerModalComponent = this;
        this.spinnerService.spinnerDisplayEvent.subscribe((data: any) => {
            if (data === true) {
                self.show();
            } else {
                self.hide();
            }
        });
    }

    private getCurrentPath(): string {
        return __moduleName.slice(0, __moduleName.lastIndexOf("/") + 1);
    }

    private concatToCurrentPath(fragment: string): string {
        return this.getCurrentPath() + fragment;
    }
}
