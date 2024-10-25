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
  analyzeData(sheet1,sheet2);
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

  var winRate = totalWins / totalRows * 100;
  var loseRate = totalLosses / totalRows * 100;

  var avgRegular = totalRegular / totalRows;
  var avgMentos = totalMentos / totalRows;
  var avgSoda = totalSoda / totalRows;


  sheet2.clear();  
  sheet2.getRange("A1").setValue("Analysis");
  sheet2.getRange("A2").setValue("Total Games");
  sheet2.getRange("A3").setValue("Wins");
  sheet2.getRange("A4").setValue("Losses");
  sheet2.getRange("A5").setValue("Win Rate (%)");
  sheet2.getRange("A6").setValue("Lose Rate (%)");
  sheet2.getRange("A7").setValue("Avg Regular Bullet");
  sheet2.getRange("A8").setValue("Avg Mentos Bullet");
  sheet2.getRange("A9").setValue("Avg Soda Bullet");

  sheet2.getRange("B2").setValue(totalRows);
  sheet2.getRange("B3").setValue(totalWins);
  sheet2.getRange("B4").setValue(totalLosses);
  sheet2.getRange("B5").setValue(winRate);
  sheet2.getRange("B6").setValue(loseRate);
  sheet2.getRange("B7").setValue(avgRegular);
  sheet2.getRange("B8").setValue(avgMentos);
  sheet2.getRange("B9").setValue(avgSoda);

  updateCharts(sheet1, sheet2);
}


function updateCharts(sheet1, sheet2) {
  var charts = sheet2.getCharts();
  for (var i = 0; i < charts.length; i++) {
    sheet2.removeChart(charts[i]);
  }
  

  var chartRange1 = sheet1.getRange('A2:D' + sheet1.getLastRow());  // Regular, Mentos, Soda 
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

  var totalRegular = sheet1.getRange('B2:B' + sheet1.getLastRow()).getValues().flat().reduce((a, b) => a + b, 0);
  var totalMentos = sheet1.getRange('C2:C' + sheet1.getLastRow()).getValues().flat().reduce((a, b) => a + b, 0);
  var totalSoda = sheet1.getRange('D2:D' + sheet1.getLastRow()).getValues().flat().reduce((a, b) => a + b, 0);

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



// for discord 
function getLastData() {
  var SpreadSheet = SpreadsheetApp.getActive();
  var sheet = SpreadSheet.getActiveSheet();
  if(sheet) {
    var lastColumn = sheet.getLastColumn();
    var lastRow = sheet.getLastRow();
    var sheetData = sheet.getSheetValues(1, 1, lastRow, lastColumn);
    var last_message = "\n";
    for (var i = 1 ; i < lastColumn; i++) {
    last_message += sheetData[0][i] + ":" + sheetData[lastRow-1][i] + "\n";
  }
  Logger.log(last_message)
  } else {
  Logger.log("Error");
  }
 
  analyzeData(sheet1,sheet2);
  return (last_message)  
}


function postMessageToDiscord(message) {
  
  last_message=getLastData()
  var message = "New test data coming！٩(*Ӧ)و\n" + "The data :"+ last_message+ "\n Click ： https://docs.google.com/spreadsheets/d/1MVZbWbCu3a73MOAOtBV29Nx5STvyRNJVQXKltmEWKuE/edit?gid=0#gid=0  For check";

  var discordUrl_1 = 'https://discord.com/api/webhooks/1299206260440305684/T8UqaXf7SF82x9L2pDWTUBYhn1J-xm5TL86eUHUWVxKQN0e6ANwajb8VNcR6rE5r6b42';
  var payload = JSON.stringify({content: message});

  var params = {
    method: "POST",
    payload: payload,
    muteHttpExceptions: true,
    contentType: "application/json"
  };

  var response_1 = UrlFetchApp.fetch(discordUrl_1, params);
  Logger.log(response_1.getContentText());

}






