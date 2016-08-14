export class Timesheet {
	timesheetId: string;
	status: TimesheetStatus;
	startDate: Date;
	endDate: Date;
}

export enum TimesheetStatus {
	New = 1
}