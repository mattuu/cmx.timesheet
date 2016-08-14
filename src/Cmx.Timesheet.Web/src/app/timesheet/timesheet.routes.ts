import { RouterConfig } from "@angular/router";

import { TimesheetListComponent, TimesheetDetailsComponent } from "./index";

export const TIMESHEET_ROUTES: RouterConfig = [
    {
        path: "timesheet",
        component: TimesheetListComponent
    },
    {
        path: "timesheet/:id",
        component: TimesheetDetailsComponent
    }
];
