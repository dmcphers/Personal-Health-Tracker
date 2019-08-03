google.charts.load('current', { 'packages': ['corechart', 'line'] });

// get the button to execute the following action on click event
$('.js-chart-with-date-range').click(() => {

    // get dates
    var fromDate = $('.js-from-date').val();
    var toDate = $('.js-to-date').val();

    // TODO: Validate that both dates are entered before getting data
    getSlpData(fromDate, toDate);
});

function getSlpData(fromDate, toDate) {

    $.get({
        url: '/chart/GetSLPChartData',
        data: {
            'fromDate': fromDate,
            'toDate': toDate
        },
        dataType: 'json',
        success: result => drawChart(result)
    });
}

function drawChart(result) {
    var dataArray = [['Date', 'Hours']];
    result.forEach((activity) => {
        activity.date = activity.date.substring(5, 10) + "-" + activity.date.substring(0, 4);
        dataArray.push([activity.date, activity.hours]);
    });

    var tableData = new google.visualization.arrayToDataTable(dataArray);

    var chartOptions = {
        title: "Sleep Chart",
        'width': 600,
        'height': 500,
        hAxis: {
            title: 'Date',
            minValue: 0
        },
        vAxis: {
            title: 'Number of Hours'
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('slpChart'));
    chart.draw(tableData, chartOptions);
}