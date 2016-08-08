export interface ButtonOption {
    text: string;
    onClick: Function;
    classes: string;
    closeOnClick: boolean;

}
export interface ConfirmationModalDisplayEventData {
    title: string;
    message: string;
    buttons: Array<ButtonOption>;
    context: ModalContext;
    dismissable: boolean;
}

export type ModalContext = "info" | "warn" | "danger";

export type ConfirmationModalDiaplayEvent = ConfirmationModalDisplayEventData | boolean;
