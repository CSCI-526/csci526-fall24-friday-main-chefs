function doPost(e) {
  try {
    // Get the spreadsheet
    const ss = SpreadsheetApp.openById("1WxnXdnsXESSY5M87cJSneoM3CR2xwcbh8BGTz7WCTGk");
    const sheet = ss.getSheetByName("Sheet1");
    
    // Parse the received JSON data
    const jsonData = JSON.parse(e.parameter.data);
    
    // Get the next row after the last row
    const nextRow = sheet.getLastRow() + 1;
    
    // Prepare the data row to be written
    const rowData = [];
    for (let i = 0; i < jsonData.length; i++) {
      rowData.push(jsonData[i]);
    }
    
    // Write data to the sheet
    sheet.getRange(nextRow, 1, 1, rowData.length).setValues([rowData]);
    
    // Return success message
    return ContentService.createTextOutput(JSON.stringify({
      'status': 'success',
      'message': 'Data successfully written'
    })).setMimeType(ContentService.MimeType.JSON);
    
  } catch(error) {
    // Return error message
    return ContentService.createTextOutput(JSON.stringify({
      'status': 'error',
      'message': error.toString()
    })).setMimeType(ContentService.MimeType.JSON);
  }
}
