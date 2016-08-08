import {Component, Input} from "@angular/core";

export const DEFAULT_SPINNER_MESSAGE: string = "";
export const DEFAULT_SPINNER_IMAGE: string = "loader.gif";

@Component({
    moduleId: __moduleName,
    selector: "j2bi-spinner",
    templateUrl: "spinner.component.html",
    styleUrls: ["spinner.component.css"]
})
export class SpinnerComponent {
    @Input() message: string;
    @Input() spinnerImage: string;
    @Input() isBusy: any;
    @Input() spinnerSize: string;

    constructor() {
        this.message = this.message || DEFAULT_SPINNER_MESSAGE;
        this.spinnerImage = this.spinnerImage || this.concatToCurrentPath(DEFAULT_SPINNER_IMAGE);
        this.spinnerSize = this.spinnerSize || "25";
    }

    private getCurrentPath(): string {
        return __moduleName.slice(0, __moduleName.lastIndexOf("/") + 1);
    }

    private concatToCurrentPath(fragment: string): string {
        return this.getCurrentPath() + fragment;
    }
}
