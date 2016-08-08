import {Injectable, EventEmitter} from "@angular/core";

import {ButtonOption, ConfirmationModalDiaplayEvent, ModalContext} from "./confirmation-modal.model";

@Injectable()
export class ConfirmationModalService {
    confirmationModalDisplayEvent: EventEmitter<ConfirmationModalDiaplayEvent>;

    constructor() {
        this.confirmationModalDisplayEvent = new EventEmitter<ConfirmationModalDiaplayEvent>();
    }

    show(title: string, message: string, buttons: Array<ButtonOption>, context: ModalContext = "info", dismissable: boolean = false): void {
        this.confirmationModalDisplayEvent.emit({
            title: title,
            message: message,
            buttons: buttons,
            context: context,
            dismissable: dismissable
        });
    }

    hide(): void {
        this.confirmationModalDisplayEvent.emit(false);
    }
}



