import { RouterConfig }          from "@angular/router";

import { TimesheetListComponent }     from "./index";

export const TIMESHEET_ROUTES: RouterConfig = [
    { path: "timesheet", component: TimesheetListComponent }
];
