export class Time {
	public Hours: number;
	public Minutes: number;

	constructor() {
		// code...
		this.Hours = 0;
		this.Minutes = 0;
	}

	public fromString(time: string): void {
		let date = new Date(time);
		this.fromDate(date);
	}

	public fromDate(date: Date): void {
		this.Hours = date.getHours();
		this.Minutes = date.getMinutes();
	}
}

export class WorkDay {
  public startTime: Time;
  public endTime: Time;
  public breakDuration: Time;

  constructor(public date: Date) {
  	// code...
  }
}