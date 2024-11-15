function calculateLevelTimes() {
    // Open the spreadsheet and get Sheet1 and Sheet2
    var app = SpreadsheetApp.openById("1TCPiJOTtKbjM42yCKBfJMm-2jdJu5sZ7KNEfXhqiFKk");
    var sheet1 = app.getSheetByName("Sheet1");
    var sheet2 = app.getSheetByName("Sheet2");
  
    if (!sheet1 || !sheet2) {
      return ContentService.createTextOutput("Error: Sheet1 or Sheet2 not found");
    }
  
    // Read data from sheet1
    var dataRange = sheet1.getDataRange();
    var data = dataRange.getValues();
  
    // Clear old data in sheet2
    sheet2.clear();
  
    // Set headers explicitly in the first row
    sheet2.getRange("A1").setValue("Level");
    sheet2.getRange("B1").setValue("Avg Time");
    sheet2.getRange("C1").setValue("Total Time");
  
    // Initialize variables to calculate total and average completion time
    var totalCompletionTime = 0;
    var levelCount = 0;
  
    // Loop through each level column in sheet1 (starting from the first level column)
    for (var col = 1; col < data[0].length; col++) {
      var levelName = "Level" + col;
      var levelValues = data.slice(1).map(row => row[col]).filter(value => !isNaN(value) && value !== "");
  
      // Calculate the total and average time for this level
      var totalTime = levelValues.reduce((a, b) => a + b, 0);
      var avgTime = levelValues.length > 0 ? totalTime / levelValues.length : 0;
      
      // Add to the total completion time and increment level count
      totalCompletionTime += totalTime;
      levelCount++;
  
      // Write each level's data to sheet2 starting from row 2
      sheet2.getRange(col + 1, 1).setValue(levelName); // Level name in column A
      sheet2.getRange(col + 1, 2).setValue(avgTime);   // Avg time in column B
      sheet2.getRange(col + 1, 3).setValue(totalTime); // Total time in column C
    }
  
    // Calculate and write the overall total completion time and average completion time at the end
    var averageCompletionTime = levelCount > 0 ? totalCompletionTime / levelCount : 0;
    sheet2.getRange("A" + (data[0].length + 1)).setValue("Overall");
    sheet2.getRange("B" + (data[0].length + 1)).setValue(averageCompletionTime);
    sheet2.getRange("C" + (data[0].length + 1)).setValue(totalCompletionTime);
  }
  