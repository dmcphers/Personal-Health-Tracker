google.charts.load('current', { 'packages': ['corechart', 'bar'] });

// before you had a form to send the data, that will cause the app to navigate to the controller action
// What you need to do is an ajax call when the button is clicked to prevent a redirect (send dates)
// Once the ajax called is completed (data received), then the chart should be displayed.

// get the button to execute the following action on click event
$('.js-chart-with-date-range').click(() => {

    // get dates
    var fromDate = $('.js-from-date').val();
    var toDate = $('.js-to-date').val();

    // TODO: Validate that both dates are enter before getting data
    getPaData(fromDate, toDate);
});

function getPaData(fromDate, toDate) {
    // https://api.jquery.com/jQuery.get/#jQuery-get-settings
    $.get({
        url: '/chart/GetPAChartData',
        data: {
            'fromDate': fromDate,
            'toDate': toDate
        },
        dataType: 'json',
        success: result => drawChart(result)
    });
}

function drawChart(result) {
    var dataArray = [['Activity', 'Duration']];
    result.forEach((activity) => {
        dataArray.push([activity.description, activity.duration]);
    });

    var tableData = new google.visualization.arrayToDataTable(dataArray);

    var chartOptions = {
        title: "Real-Time Chart",
        'width': 600,
        'height': 500,
        hAxis: {
            title: 'Total Population',
            minValue: 0
        },
        vAxis: {
            title: 'City'
        }
    };

    var chart = new google.visualization.BarChart(document.getElementById('paChart'));
    chart.draw(tableData, chartOptions);
}