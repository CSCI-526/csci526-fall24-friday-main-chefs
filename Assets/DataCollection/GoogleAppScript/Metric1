var app = SpreadsheetApp.openById("1MVZbWbCu3a73MOAOtBV29Nx5STvyRNJVQXKltmEWKuE");
var sheet1 = app.getSheets()[0];  
var sheet2 = app.getSheets()[1];  

function doPost(e) {
  if (sheet1.getLastRow() == 0) {
    sheet1.getRange("A1").setValue("Result");
    sheet1.getRange("B1").setValue("RegularBullet");
    sheet1.getRange("C1").setValue("MentosBullet");
    sheet1.getRange("D1").setValue("SodaBullet");
  }
  analyzeData(sheet1, sheet2);
}

function analyzeData(sheet1, sheet2) {
  var data = sheet1.getDataRange().getValues();
  
  var totalRows = data.length - 1; 
  var totalWins = 0, totalLosses = 0;
  var totalRegular = 0, totalMentos = 0, totalSoda = 0;

  for (var i = 1; i < data.length; i++) {
    var result = data[i][0]; // "Result" column
    var regular = Number(data[i][1]); // "RegularBullet"
    var mentos = Number(data[i][2]); // "MentosBullet"
    var soda = Number(data[i][3]); // "SodaBullet"

    // 計算勝利和失敗次數
    if (result == "Win") {
      totalWins++;
    } else if (result == "Lose") {
      totalLosses++;
    }

    totalRegular += regular;
    totalMentos += mentos;
    totalSoda += soda;
  }

  var winRate = (totalWins / totalRows) * 100;
  var loseRate = (totalLosses / totalRows) * 100;
  var avgRegular = totalRegular / totalRows;
  var avgMentos = totalMentos / totalRows;
  var avgSoda = totalSoda / totalRows;

  sheet2.clear();  

  // 設置橫向表格的標題
  sheet2.getRange("A1").setValue("Total Games");
  sheet2.getRange("B1").setValue("Wins");
  sheet2.getRange("C1").setValue("Losses");
  sheet2.getRange("D1").setValue("Win Rate (%)");
  sheet2.getRange("E1").setValue("Lose Rate (%)");
  sheet2.getRange("F1").setValue("Avg Regular Bullet");
  sheet2.getRange("G1").setValue("Avg Mentos Bullet");
  sheet2.getRange("H1").setValue("Avg Soda Bullet");
  sheet2.getRange("I1").setValue("RegularBullet");
  sheet2.getRange("J1").setValue("MentosBullet");
  sheet2.getRange("K1").setValue("SodaBullet");

  // 填入統計數據
  sheet2.getRange("A2").setValue(totalRows);
  sheet2.getRange("B2").setValue(totalWins);
  sheet2.getRange("C2").setValue(totalLosses);
  sheet2.getRange("D2").setValue(winRate);
  sheet2.getRange("E2").setValue(loseRate);
  sheet2.getRange("F2").setValue(avgRegular);
  sheet2.getRange("G2").setValue(avgMentos);
  sheet2.getRange("H2").setValue(avgSoda);
  sheet2.getRange("I2").setValue(totalRegular);
  sheet2.getRange("J2").setValue(totalMentos);
  sheet2.getRange("K2").setValue(totalSoda);

  updateCharts(sheet1, sheet2);
}

function updateCharts(sheet1, sheet2) {
  var charts = sheet2.getCharts();
  for (var i = 0; i < charts.length; i++) {
    sheet2.removeChart(charts[i]);
  }

  // 創建新的圖表（保持現有圖表設置）
  var chartRange1 = sheet1.getRange('A2:D' + sheet1.getLastRow());
  var newChart1 = sheet2.newChart()
    .setChartType(Charts.ChartType.COLUMN)
    .addRange(chartRange1)
    .setPosition(16, 2, 0, 0)
    .setOption('width', 800)
    .setOption('height', 400)
    .setOption('title', 'Bullet Quantity and Type vs Win/Loss')
    .setOption('isStacked', true)
    .setOption('legend', {position: 'right', textStyle: {fontSize: 12}})
    .setOption('hAxis.title', 'Games')
    .setOption('vAxis.title', 'Bullet Quantity')
    .setOption('colors', ['#ffd966', '#00ffff', '#dd7e6b'])
    .build();
  sheet2.insertChart(newChart1);

  var bulletDistributionRange = [
    ['RegularBullet', totalRegular],
    ['MentosBullet', totalMentos],
    ['SodaBullet', totalSoda]
  ];
  var chartRange3 = sheet2.getRange('A10:B12');
  chartRange3.setValues(bulletDistributionRange);

  var newChart3 = sheet2.newChart()
    .setChartType(Charts.ChartType.PIE)
    .addRange(chartRange3)
    .setPosition(36, 2, 0, 0)
    .setOption('width', 400)
    .setOption('height', 300)
    .setOption('title', 'Bullet Type Distribution')
    .setOption('legend', {position: 'right', textStyle: {fontSize: 12}})
    .setOption('colors', ['#ffd966', '#00ffff', '#dd7e6b']) 
    .build();
  sheet2.insertChart(newChart3);

  var chartRange2 = sheet2.getRange('A3:B4');  // Wins and Losses 的範圍
  var newChart2 = sheet2.newChart()
    .setChartType(Charts.ChartType.PIE)
    .addRange(chartRange2)
    .setPosition(36, 6, 0, 0)
    .setOption('width', 400)
    .setOption('height', 300)
    .setOption('title', 'Win/Loss Distribution')
    .setOption('legend', {position: 'right', textStyle: {fontSize: 12}})
    .setOption('colors', ['#ea4335', '#4285f4'])  
    .build();
  sheet2.insertChart(newChart2);
} 