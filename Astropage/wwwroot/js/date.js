// Källor: https://www.w3schools.com/jsref/jsref_getdate.asp
// https://www.youtube.com/watch?v=CnozSz4wbBQ
document.addEventListener('DOMContentLoaded', function () {
    var today = new Date();
    var day = today.getDate();
    var month = today.getMonth() + 1; //  räknas från 0 till 11, lägg till 1
    var year = today.getFullYear();

    var currentDate = day + '/' + month + '/' + year;
    var currentMonthDate = month + '/' + year;

    document.getElementById('date-display').innerText = currentDate;
    document.getElementById('month-date-display').innerText = currentMonthDate;
});
