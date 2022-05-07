//includes
const opggScraper = require('opgg-scraper');
const prompt = require('prompt');

//Setup
prompt.message = "";
prompt.delimiter = ": ";
prompt.start();

//Main Loop
Main();
function Main () {
    prompt.get("Command", function (err, result) {
        Think(result.Command);
        //if (Think(result.Command) === true) {
           // Loop();
        //}
    });
}

//Think
function Think (input) {
    if(input === "exit") {
        process.exit();
    }
    else {
        GetChamp(input);
    }
}

//Op.gg scrapper
async function GetChamp (input) {
    await opggScraper.getStats(input, 'oce', false).then(stats => console.log(stats));
    Main();
}