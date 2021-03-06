﻿google.charts.load('current', { 'packages': ['corechart', 'line'] });

// get the button to execute the following action on click event
$('.js-chart-with-date-range').click(() => {

    // get dates
    var fromDate = $('.js-from-date').val();
    var toDate = $('.js-to-date').val();

    // TODO: Validate that both dates are entered before getting data
    getPaData(fromDate, toDate);
});

function getPaData(fromDate, toDate) {
    
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
    var dataArray = [['Date', 'Duration']];
    result.forEach((activity) => {
        dataArray.push([activity.date, activity.duration]);
    });

    var tableData = new google.visualization.arrayToDataTable(dataArray);

    var chartOptions = {
        title: "Real-Time Chart",
        'width': 600,
        'height': 500,
        hAxis: {
            title: 'Date',
            minValue: 0
        },
        vAxis: {
            title: 'Number of Minutes'
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('paChart'));
    chart.draw(tableData, chartOptions);
}