import {Injectable, EventEmitter} from "@angular/core";

@Injectable()
export class SpinnerModalService {

    spinnerDisplayEvent: EventEmitter<boolean>;

    constructor() {
        this.spinnerDisplayEvent = new EventEmitter<boolean>();
    }

    show(): void {
        this.spinnerDisplayEvent.emit(true);
    }

    hide(): void {
        this.spinnerDisplayEvent.emit(false);
    }
}
