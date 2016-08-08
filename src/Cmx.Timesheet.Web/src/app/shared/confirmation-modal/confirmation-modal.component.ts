import {Component} from "@angular/core";
import "bootstrap";

import {ConfirmationModalService} from "./confirmation-modal.service";
import {
    ConfirmationModalDiaplayEvent,
    ConfirmationModalDisplayEventData,
    ButtonOption, ModalContext
} from "./confirmation-modal.model";

@Component({
    moduleId: __moduleName,
    selector: "j2bi-confirmation-modal",
    templateUrl: "confirmation-modal.component.html",
    styleUrls: ["confirmation-modal.component.css"]
})
export class ConfirmationModalComponent {
    title: string;
    message: string;
    dismissable: boolean;
    context: ModalContext;
    buttons: Array<ButtonOption>;

    constructor(private confirmationModalService: ConfirmationModalService) {
        this.addEventSubscriptions();
    }

    create(
        {title,
            message,
            buttons,
            context,
            dismissable}: ConfirmationModalDisplayEventData): void {
        this.title = title;
        this.message = message;
        this.buttons = buttons;
        this.context = context;
        this.dismissable = dismissable;
    }

    hide(): void {
        let $modal: any = $("#j2bi-confirmation-modal");
        $modal.modal("hide");
    }

    show(): void {
        let $modal: any = $("#confirm-modal");
        $modal.modal("show");
    }

    // TODO: MV: make it a pipe
    dismissAttrValue(canClose: boolean): string {
        if (canClose) {
            return "modal";
        }
        return "";
    }

    private addEventSubscriptions(): void {
        let self: ConfirmationModalComponent = this;
        this.confirmationModalService.confirmationModalDisplayEvent.subscribe((data: ConfirmationModalDiaplayEvent) => {
            if (data) {
                let dialogData: ConfirmationModalDisplayEventData = data as ConfirmationModalDisplayEventData;
                self.create(dialogData);
                self.show();
            } else {
                self.hide();
            }
        });
    }
}


