google.charts.load('current', { 'packages': ['corechart', 'line'] });

// get the button to execute the following action on click event
$('.js-chart-with-date-range').click(() => {

    // get dates
    var fromDate = $('.js-from-date').val();
    var toDate = $('.js-to-date').val();

    // TODO: Validate that both dates are entered before getting data
    getNutData(fromDate, toDate);
});

function getNutData(fromDate, toDate) {

    $.get({
        url: '/chart/GetNUTChartData',
        data: {
            'fromDate': fromDate,
            'toDate': toDate
        },
        dataType: 'json',
        success: result => drawChart(result)
    });
}

function drawChart(result) {
    var dataArray = [['Date', 'Calories']];
    result.forEach((activity) => {
        dataArray.push([activity.date, activity.calories]);
    });

    var tableData = new google.visualization.arrayToDataTable(dataArray);

    var chartOptions = {
        title: "Nutrition Chart",
        'width': 600,
        'height': 500,
        hAxis: {
            title: 'Date',
            minValue: 0
        },
        vAxis: {
            title: 'Number of Calories'
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('nutChart'));
    chart.draw(tableData, chartOptions);
}