
#r "bin/debug/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

open FSharp.Data

let csv = new CsvProvider<"500-uk.csv">()

let data = 
    csv.Data 
    |> Seq.iter (fun t -> printf "%s %s\n" t.``First Name`` t.``Last Name``)

let data = 
    csv.Data 
    |> Seq.filter (fun r -> r.City = "Edgbaston") 
    |> Seq.iter (fun t -> printf "%s %s\n" t.``First Name`` t.``Last Name``)

let csv = new CsvProvider<"500-uk-no-header.csv", Schema="Id,First Name,Last Name,Phone,Fax,Email,Address1,Address2,City,Postcode,Company,EmployeeRef,Web">()

let data = 
    csv.Data 
    |> Seq.filter (fun r -> r.Postcode.StartsWith("CV")) 
    |> Seq.iter (fun t -> printf "%s %s - %s\n" t.``First Name`` t.``Last Name`` t.Postcode)
