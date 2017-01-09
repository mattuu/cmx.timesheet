export class Calendar {
	constructor(public startDate: Date, public endDate: Date) {
		// code...
		this.dates = new Array<CalendarDate>();

		for (var i = startDate.getDate() - 1; i >= 0; i--) {
			this.dates.push(new CalendarDate(undefined, false));
		}

		let date = this.startDate;
		while(date <= this.endDate) {
  		// if(date.getDay() == 0){
  		// 	week = new Array<Date>();
	  	// 	this.dates.push(week);
  		// }

	  		this.dates.push(new CalendarDate(date, true));

	  		// console.log(d);
	  			// week.push(d);

	  		date.setDate(date.getDate() + 1);
	  	}


	}

	public dates: Array<CalendarDate>;
}

export class CalendarDate {
	constructor(public date: Date, public inCalendar: boolean) {
		// code...
	}
}