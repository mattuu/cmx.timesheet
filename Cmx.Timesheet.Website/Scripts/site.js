$().ready(function() {
    $('.datepicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showOn: "button",
        buttonImage: "/Images/calendar.gif",
        buttonImageOnly: true
    });
});

//var TotalHrsCalculator = function() {
    
//}

function calculateTotalHrs(inputs) {

        var startTimeVal = inputs.startTime.val();
        var endTimeVal = inputs.endTime.val();
        var breakStartTimeVal = inputs.breakStartTime.val();
        var breakEndTimeVal = inputs.breakEndTime.val();
        //alert(startTime);

        //var startDate = new Date(new Date().toShortDate() + startTimeVal);
        debugger;

        var startTime = moment(startTimeVal, "HH:mm:ss");
        var endTime = moment(endTimeVal, "HH:mm:ss");
        var breakStartTime = moment(breakStartTimeVal, "HH:mm:ss");
        var breakEndTime = moment(breakEndTimeVal, "HH:mm:ss");

        var dayDuration = endTime.subtract(startTime.hours(), 'h');
        dayDuration = dayDuration.subtract(startTime.minutes(), 'm');
        dayDuration = dayDuration.subtract(startTime.seconds(), 's');

        var breakDuration = breakEndTime.subtract(breakStartTime);

        var duration = dayDuration.subtract(breakDuration);
}