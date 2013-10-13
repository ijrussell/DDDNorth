#r "bin/debug/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

open FSharp.Data

type json = JsonProvider<"random.json">

let data = json.Load("random.json")

for item in data do
    printfn "%s [%s]" item.Name item.Company

let data = 
    json.Load("random.json")
    |> Array.iter (fun item -> printfn "%s [%s]" item.Name item.Company)

let data = 
    json.Load("random.json")
    |> Array.iter (fun item -> printfn "%s [%s]" item.Name (item.Tags |> Array.reduce (fun acc tag -> acc + "," + tag)))