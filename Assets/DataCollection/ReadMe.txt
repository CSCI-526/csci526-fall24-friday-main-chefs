** DashBoard: https://lookerstudio.google.com/reporting/a11c066f-25db-44fa-82bb-9f5d68fe6bff **

The homepage is a summary based on various statistics and the average number of bullets used in each level. The following is the average bullet composition analyzed based on the number of wins and losses.
The second page starts with creating bullet usage trends for each game, including the total amount of bullets and bullet classification.
Directly below are simple win-loss statistics and % percentages.
When we click on the required statistic, the entire dashboard will react based on the statistic.
For example: When I click the "lose" option, we can see that the bullet total trend chart above changes accordingly, and the lose statistics on the right also show the total number of losses.
Autumn — 2024/11/05 19:46
The third page is the newly added usage time analysis of each level. Thanks Koi for all the information. The chart may not look good right now because the test data volume is so small, with only two transactions. After testing it more and adding test data , it should look good.
And of course there's a raw data table for checking the raw data.  You can click on any piece of content that interests you, and the report will give you an analysis response.
Based on the content of the last class, I think this will be the platform and technology used fior our final version. Please kindly review that and give me some feedbacks.

Bullet Performance Analysis
Overview
This script analyzes the performance of three types of bullets—RegularBullet, MentosBullet, and SodaBullet—based on game outcomes (Win/Lose). It calculates summary statistics such as win/loss rates and average bullet usage, then visualizes these metrics in column and pie charts.

Setup
Link the script to your Google Sheet by providing the spreadsheet ID in the app variable.
Ensure that Sheet1 holds the raw game data, while Sheet2 will store the analysis results.
Features
Data Aggregation: Calculates the total number of games, wins, and losses, and computes the win/loss rate.
Bullet Statistics: Computes the total and average usage for each bullet type.
Charts: Creates the following charts:
Column Chart: Displays bullet type usage across games.
Pie Chart: Shows the distribution of bullet types and win/loss rates.
Functions
doPost(e): Initializes headers in Sheet1 if empty, then calls analyzeData().
analyzeData(sheet1, sheet2): Aggregates game results, calculates win/loss rates, and bullet usage stats. Clears Sheet2 and inserts calculated data.
updateCharts(sheet1, sheet2): Creates or updates column and pie charts to visualize the analysis.



Level Completion Time Analysis
Overview
This script calculates and summarizes completion times for various game levels based on data in Sheet1. The analysis includes average and total completion times per level and overall.

Setup
Link the script to your Google Sheet by providing the spreadsheet ID in the app variable.
Ensure that Sheet1 contains the level completion times data and Sheet2 will store the results.
Features
Completion Time Calculation: Aggregates total and average times per level and computes an overall average completion time.
Data Visualization: Displays level-wise summary data for easy review.
Functions
calculateLevelTimes():
Reads level data from Sheet1.
Calculates and stores average and total times per level in Sheet2.
Calculates overall average and total completion times and appends these results to Sheet2.
