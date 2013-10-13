#r "bin/debug/FSharp.Data.dll"

open FSharp.Data

let data = WorldBankData.GetDataContext()

data.Countries.``United Kingdom``.Indicators.``Central government debt, total (% of GDP)``
|> Seq.maxBy fst


#load "../packages/FSharp.Charting.0.87/FSharp.Charting.fsx"

open FSharp.Charting

let data = WorldBankData.GetDataContext()

data.Countries.``United Kingdom``
    .Indicators.``School enrollment, tertiary (% gross)``
|> Chart.Line

// -----------------------------------------------------
// Asynchronous

type WorldBank = WorldBankDataProvider<"World Development Indicators", Asynchronous=true>

let wb = WorldBank.GetDataContext()
 
// Create a list of countries to process
let countries = 
    [| wb.Countries.``Arab World``; wb.Countries.``European Union``
       wb.Countries.Australia; wb.Countries.Brazil
       wb.Countries.Canada; wb.Countries.Chile
       wb.Countries.``Czech Republic``
       wb.Countries.Denmark; wb.Countries.France
       wb.Countries.Greece; wb.Countries.``Low income``
       wb.Countries.``High income``; wb.Countries.``United Kingdom``
       wb.Countries.``United States`` |]


[ for c in countries ->
    c.Indicators.``School enrollment, tertiary (% gross)`` ]
|> Async.Parallel
|> Async.RunSynchronously
|> Array.map Chart.Line
|> Chart.Combine