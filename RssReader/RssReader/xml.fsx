#r "bin/debug/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

open FSharp.Data

type rss = XmlProvider<"tekpub_rss.xml">

let title =
    let feed = rss.GetSample()
    printfn "Channel Title: %s" feed.Channel.Title

// Get all item nodes and print title with link
//for item in feed.Channel.GetItems() do
//   printfn " - %s (%O)" item.Title item.PubDate

let test =
    let feed = rss.GetSample() 
    feed.Channel.GetItems()
    |> Array.sortBy (fun c -> c.PubDate) 
    |> Array.rev 
    |> Array.iter (fun item -> printfn " - %s (%O)" item.Title item.PubDate)

